    private static void CountGroupOccurrences(string str, params string[] patterns)
    {
        string result = string.Empty;
        foreach (string pattern in patterns)
        {
            result += string.Format("{0}({1})", Regex.Matches(str, pattern).Count, pattern);
        }
        Console.WriteLine(result);
    }
