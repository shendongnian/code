    public override bool Equals(IList<string> x, IList<string> y)
    {
        return Enumerable.SequenceEqual(x.OrderBy(i => i), y.OrderBy(i => i));
    }
    public override int GetHashCode(IList<string> obj)
    {
        return obj.Select(i => i.GetHashCode()).Average().GetHashCode();
    }
