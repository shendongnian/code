    public static bool HasSubSequence(List<int> main, List<int> query)
    {
        var startIndex = main.IndexOf(query.First());
        if (main == null || query == null ||
                startIndex < 0 || main.Count - startIndex < query.Count)
            return false;
        for (int i = 0; i < query.Count; i++)
        {
            if (main[i + startIndex] != query[i])
                return false;
        }
        return true;
    }
