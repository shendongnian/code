    public object Clone()
    {
        var copy = new Solution();
        foreach (var pair in solution)
            copy.solution.Add(new Room(pair.Key), pair.Value.ToList());
        return copy;
    }
