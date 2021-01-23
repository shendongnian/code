    public static void Main()
    {
        string input = @"other[aa][][a]";
        string pattern = @"\[[^][]*]";
        Match m = Regex.Match(input, pattern, RegexOptions.RightToLeft);
       
        if (m.Success)
            Console.WriteLine("Found '{0}' at position {1}.", m.Value, m.Index);
    }
