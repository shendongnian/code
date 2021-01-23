    class Program
    {
        static void Main(string[] args)
        {
            @"
    This is in ~r~red~~ and this is in ~b~blue~~. This is just some more text 
    to work it out a bit. ~g~And now a bit of green~~.
    ".WriteToConsole();
        }
    }
    static public class StringConsoleExtensions
    {
        private static readonly Dictionary<string, ConsoleColor> ColorMap = new Dictionary<string, ConsoleColor>
        {
            { "r", ConsoleColor.Red },
            { "b", ConsoleColor.Blue },
            { "g", ConsoleColor.Green },
            { "w", ConsoleColor.White },
        };
        static public void WriteToConsole(this string value)
        {
            var position = 0;
            foreach (Match match in Regex.Matches(value, @"~(r|g|b|w)~([^~]*)~~"))
            {
                var leadingText = value.Substring(position, match.Index - position);
                position += leadingText.Length + match.Length;
                Console.Write(leadingText);
                var currentColor = Console.ForegroundColor;
                try
                {
                    Console.ForegroundColor = ColorMap[match.Groups[1].Value];
                    Console.Write(match.Groups[2].Value);
                }
                finally
                {
                    Console.ForegroundColor = currentColor;
                }
            }
            if (position < value.Length)
            {
                Console.Write(value.Substring(position, value.Length - position));
            }
            Console.ReadKey();
        }
    }
