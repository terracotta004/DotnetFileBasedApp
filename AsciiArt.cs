#:package Colorful.Console@1.2.15

using System.Drawing;

if (args.Length > 0)
{
    string message = string.Join(' ', args);
    Console.WriteLine(message);
}
else
{
    while (Console.ReadLine() is string line 
    // && line.Length > 0
    )
    {
        await WriteAsciiArt(new AsciiMessageOptions
        {
            Messages = new[] { line },
            Delay = 500
        });
    }
}

async Task WriteAsciiArt(AsciiMessageOptions options)
{
    if (options.Messages != null)
    {
        foreach (string message in options.Messages)
        {
            Colorful.Console.WriteAscii(message, Color.White);
            await Task.Delay(options.Delay);
        }
    }
}

public class AsciiMessageOptions
{
    public string[]? Messages { get; set; }
    public int Delay { get; set; }
}