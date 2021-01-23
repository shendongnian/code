    static string ProcessString(string input)
    {
        var segments = input.Split(' ').Select(s =>
        {
            List<string> parts = new List<string>(s.Length / 2);
            for (int i = 0; i < s.Length; i += 2)
                parts.Add(s.Substring(i, 2));
            return string.Join("-", parts);
        });
        return string.Join(" ", segments);
    }
