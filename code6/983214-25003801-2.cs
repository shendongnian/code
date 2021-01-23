    public bool IsUniform()
    {
        var values = PointForceSet.Values;
        if (values.Count == 0)
            return false; // Normally would be true - handling your req. based on comments
        var first = values.First();
        return values.Skip(1).All(v => v.Equals(first));
    }
