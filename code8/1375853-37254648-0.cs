    public List<string> GetMostFrequentWords(List<string> list)
    {
        var groups = list.GroupBy(x => x).Select(x => new { word = x.Key, Count = x.Count() }).OrderByDescending(x => x.Count);
        if (!groups.Any()) return new List<string>();
        var maxCount = groups.First().Count;
        return groups.Where(x => x.Count == maxCount).Select(x => x.word).OrderBy(x => x).ToList();
    }
        
    [TestMethod]
    public void Test()
    {
        var list = @"Dubai,Karachi,Lahore,Madrid,Dubai,Sydney,Sharjah,Lahore,Cairo".Split(',').ToList();
        var result = GetMostFrequentWords(list);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Dubai", result[0]);
        Assert.AreEqual("Lahore", result[1]);
    }
