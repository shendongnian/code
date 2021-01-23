    private static IEnumerable<string> getPermutations(int n,string source)
    {
        IEnumerable<string> q = source.Select(x => x.ToString());
        for (int i = 0; i < n - 1; i++)
        {
            q = q.SelectMany(x => source, (x, y) => x + y);
        }
        return q; 
    }
    private static List<string> filterListByRegex(IEnumerable<string> list, string regex)
    {
        List<string> newList = new List();
        foreach(var item in list)
        {
            Match match = Regex.Match(item, regex, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                newList.Add(item);
            }
        }
        
        return newList;
    }
