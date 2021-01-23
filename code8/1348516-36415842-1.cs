    public static IEnumerable<int> FindIndexes(string text, string query)
    {
        return Enumerable.Range(0, text.Length - query.Length)
            .Where(i => query.Equals(text.Substring(i, query.Length));
    }
