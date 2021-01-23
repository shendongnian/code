    public IEnumerator<int> GetEnumerator()
    {
        if (!ShouldGenerate)
            return Enumerable.Empty<int>().GetEnumerator();
        return new RangeIterator(ref this);
    }
