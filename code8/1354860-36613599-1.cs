    [TestMethod]
    public void splits_100_by_3_into_34()
    {
        var values = Enumerable.Range(1, 100);
        var splitValues = values.Split(3);
        Assert.AreEqual(splitValues.Count(), 34);
        Assert.IsTrue(splitValues.ElementAt(0).SequenceEqual(Enumerable.Range(1, 3)));
        Assert.AreEqual(splitValues.ElementAt(33).Count(), 1);
        Assert.AreEqual(splitValues.ElementAt(33).ElementAt(0), 100);
    }
