    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void FindMostFrequentPair_WithNull_ThrowsArgumentNullException()
    {
        var pair = Utils.FindMostFrequestPair(null);
    }
    [TestMethod]
    public void FindMostFrequentPair_WithSameFrequentPairs_ReturnsFirst()
    {
        var pair = Utils.FindMostFrequestPair("ABCD");
        Assert.AreEqual("AB", pair);
    }
