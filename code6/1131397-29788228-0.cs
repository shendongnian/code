    static void Main()
    {
        string text = File.ReadAllText(@"e:\1.txt");
        Regex regex = new Regex("Monday", RegexOptions.IgnoreCase);
        Match match = regex.Match(text);
        while (match.Success)
        {
            Console.WriteLine("'{0}' found at index {1}", match.Value, match.Index);
            match = match.NextMatch();
        }
    }
