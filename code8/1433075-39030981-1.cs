    class Program
    {
        static void Main(string[] args)
        {
            var data = new[]
            {
                "Bar",
                "Barbec",
                "Barbecue",
                "Batman",
            };
            var builder = new StringBuilder();
            var input = Console.ReadKey(intercept:true);
            while (input.Key != ConsoleKey.Enter)
            {
                var currentInput = builder.ToString();
                if (input.Key == ConsoleKey.Tab)
                {
                    var match = data.FirstOrDefault(item => item != currentInput && item.StartsWith(currentInput, true, CultureInfo.InvariantCulture));
                    if (string.IsNullOrEmpty(match))
                    {
                        input = Console.ReadKey(intercept: true);
                        continue;
                    }
                    ClearCurrentLine();
                    builder.Clear();
                    Console.Write(match);
                    builder.Append(match);
                }
                else
                {
                    if (input.Key == ConsoleKey.Backspace && currentInput.Length > 0)
                    {
                        builder.Remove(builder.Length - 1, 1);
                        ClearCurrentLine();
                        currentInput = currentInput.Remove(currentInput.Length - 1);
                        Console.Write(currentInput);
                    }
                    else
                    {
                        var key = input.KeyChar;
                        builder.Append(key);
                        Console.Write(key);
                    }
                }
                input = Console.ReadKey(intercept:true);
            }
            Console.Write(input.KeyChar);
        }
        /// <remarks>
        /// https://stackoverflow.com/a/8946847/1188513
        /// </remarks>>
        private static void ClearCurrentLine()
        {
            var currentLine = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLine);
        }
    }
