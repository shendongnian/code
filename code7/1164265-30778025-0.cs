     string[] prefixes = { "INT", "EXT" };
     for (int i = 0; i < list.Count; i++)
     {
        string oldS = list[i].Trim();
        int indexOflastSpace = oldS.LastIndexOf(' ');
        int endIndex = oldS.Length - 1;
        if(indexOflastSpace >= 0)
        {
            string rest = oldS.Substring(indexOflastSpace).TrimStart();
            // starts the last token with a digit?
            if(char.IsDigit(rest[0]))
                endIndex = indexOflastSpace;
        }
        int start = 0;
        int indexOfAnyPrefix = prefixes
            .Select(p => oldS.IndexOf(p, StringComparison.InvariantCultureIgnoreCase))
            .Where(index => index >= 0)
            .DefaultIfEmpty(-1)
            .First();
        if(indexOfAnyPrefix > 0)
            start = indexOfAnyPrefix;
        string newS = oldS.Substring(start, endIndex - start);
        list[i] = newS;
    }
