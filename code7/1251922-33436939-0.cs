    void Write(int? id, params string[] values)
    {
        var normalizedValues = values
            .Select(v => Normalize(v))
            .ToArray();
    
        // do the rest
    }
    string Normalize(string v)
    {
        return string.IsNullOrWhiteSpace(v) ? null : v.Trim();
    }
