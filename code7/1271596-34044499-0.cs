    Dictionary<string, string> delims = 
        Enumerable.Range(char.MinValue, char.MaxValue - char.MinValue)
        .Select(i => Convert.ToChar(i))
        .Where(c => !Char.IsControl(c))
        .ToDictionary(c => c.ToString(), c => c.ToString());
