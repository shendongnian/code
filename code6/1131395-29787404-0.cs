    internal static void Main(string[] args)
    {
        var dayLines = new List<string>()
            {
                "Monday Monday Monday",
                "Tuesday"
            };
        foreach (var line in dayLines.Where(l => l.Contains("Monday")))
        {
            var index = -1;
            do
            {
                index = line.IndexOf("Monday", index + 1);
                if (index > -1)
                     Console.WriteLine("The index is {0}", index);
            }
            while (index > -1);
        }
        Console.ReadLine();
    }
