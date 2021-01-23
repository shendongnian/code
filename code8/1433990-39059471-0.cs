    static void Main(string[] args)
    {
        var data = new int[11];
        while (true)
        {
            Console.Write("Enter a number [0-10] or 'q' to quit: ");
            var input = Console.ReadLine();
            var value = 0;
            if (inputIsValid(input, out value))
            {
                data[value]++;
            }
            else if (input.ToLowerInvariant() == "q")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid number, pleae try again.");
            }
        }
        Console.WriteLine();
        Console.WriteLine(printASCIIChart(data));
        Console.ReadLine();
    }
    private static bool inputIsValid(string input, out int value)
    {
        if (int.TryParse(input, out value))
        {
            if (value > -1 && value < 11)
                return true;
        }
        return false;
    }
    private static string printASCIIChart(IEnumerable<int> data)
    {
        var builder = new StringBuilder();
        var counter = 0;
        foreach (var num in data)
        {
            builder.AppendLine($"[{counter:00}]: {new string('*', num)}");
            counter++;
        }
        return builder.ToString();
    }
