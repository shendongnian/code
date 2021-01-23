        List<string> strings = new List<string> { "   Ford   ", "   Yellow   ", "  1987   " };
        Regex r = new Regex(@"\s+\w+\s+");
        foreach (var s in strings)
        {
            if (r.IsMatch(s))
            {
                var match = r.Match(s).Value;
                Console.WriteLine(string.Format("[{0}]", match.Trim()));
            }
        }
