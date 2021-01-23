    public List<string> SortList(List<string> thread)
    {
        thread = thread
            .OrderBy(str =>
            {
                var match = Regex.Match(str, @"^([-+]?\d+)\.");
                return match.Success ? int.Parse(match.Groups[1].Value) : int.MaxValue;
            })
            .ToList();
        responsers.Add(thread); // was: responsers.Add(new List<string>(thread));
        return thread;
    }
