    static IDictionary<double, double> Merge(IEnumerable<Dictionary<double, double>> dicts)
    {
        return dicts.SelectMany(p => p)
            .ToLookup(p => p.Key, p => p.Value)
            .ToDictionary(p => p.Key, p => p.Max());
    }
