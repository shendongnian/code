    public object Clone()
    {
        var copy = new Solution();
        foreach (var pair in solution)
            copy.solution.Add(new Room(pair.Key), pair.Value.Select(i => new Patient(i)).ToList());
        return copy;
    }
