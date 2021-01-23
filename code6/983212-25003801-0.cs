    public bool IsUniform()
    {
        var values = PointForceSet.Values;
        var first = PointForceSet.First();
        return values.Skip(1).All(v => v == first);
    }
