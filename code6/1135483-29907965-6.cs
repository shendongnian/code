    public static void CsvUnescapeSplit()
    {
        string[] seps = { "\",", ",\"" };
        char[] quotes = { '\"', ' ' };
        foreach (var line in File.ReadLines(@"c:\temp\test.txt"))
        {
            var fields = line
                .Split(seps, StringSplitOptions.None)
                .Select(s => s.Trim(quotes).Replace("\\\"", "\""))
                .ToArray();
            foreach (var field in fields)
                Console.Write("{0} | ", field);
            Console.WriteLine();
        }
    }
