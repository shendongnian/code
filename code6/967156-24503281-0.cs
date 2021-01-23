    private static IEnumerable<string> Substrings(string input)
    {
        for (int l = 2; l <= input.Length; l++)
        {
            for (int i = 0; i <= input.Length - l; i++)
            {
                yield return input.Substring(i, l);
            }
        }
    }
