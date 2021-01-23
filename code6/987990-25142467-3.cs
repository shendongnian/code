    private Time DecideMinTime(IEnumerable<Time> g)
    {
        if (g == null) { throw new ArgumentNullException("g"); }
        return (Time)g.Cast<int>().Min();
    }
