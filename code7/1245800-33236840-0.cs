    public mclass()
    {
        nCount = new Dictionary<string, Dictionary<string, int>>();
        var innerDict1 = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
        innerDict1.Add("Foo", 1);
        nCount.Add("Bah", innerDict1);
    }
