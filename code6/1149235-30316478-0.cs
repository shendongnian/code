    public override bool Equals(IList<string> x, IList<string> y)
    {
        return Enumerable.SequenceEqual(x.OrderBy(i => i.), y.OrderBy(i => i));
    }
    public override int GetHashCode(IEnumerable<SomeData> obj)
    {
        return obj.Select(i => i.GetHashCode()).Sum().GetHashCode();
    }
