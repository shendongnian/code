    public IEnumerable<P> Parse<P>(string[] values)
    {
        foreach (var value in values)
        {
            yield return (P)Convert.ChangeType(value, typeof(P));
        }
    }
