    public static bool HasSubSequence(List<int> main, List<int> query)
    {
        var startIndex = main.IndexOf(query.First());
        if (main == null || query == null || startIndex < 0)
            return false;
        while (startIndex >= 0)
        {        
            if (main.Count - startIndex < query.Count)
                return false;
            var nonMatch = false;
            for (int i = 0; i < query.Count; i++)
            {
                if (main[i + startIndex] != query[i])
                {
                    main = main.Skip(startIndex + 1).ToList();
                    startIndex = main.IndexOf(query.First());
                    nonMatch = true;
                    break;
                }
            }
            if (!nonMatch)
                return true;
        }
        return false;
    }
