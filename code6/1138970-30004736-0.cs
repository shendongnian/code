    public object Clone()
    {
        var copy = new Solution();
        foreach (var pair in solution)
            copy.solution.Add(pair.Key, pair.Value);
        return copy;
    }
