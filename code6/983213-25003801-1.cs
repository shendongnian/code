    public bool IsUniform()
    {
        var values = PointForceSet.Values;
        if (values.Count == 0)
            return true; // How do you want to handle no elements?
        var first = values.First();
        return values.Skip(1).All(v => v.Equals(first));
    }
