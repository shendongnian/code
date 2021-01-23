    public void AddContent(IBar bar)
    {
        var result = bar.GetStringsAsync().Result;
        MyCollection.AddRange(result);
    }
