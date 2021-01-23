    [TestMethod]
    public void splits_20_into_sets_of_seven()
    {
        var values = Enumerable.Range(1, 20);
        var splitValues = values.SplitIntoSetsOfSpecifiedLength(7).ToList();
        // three sets
        Assert.AreEqual(splitValues.Count(), 3); 
        // the first set contains the first seven numbers.
        Assert.IsTrue(splitValues[0].SequenceEqual(Enumerable.Range(1, 7)));
        // the second set contains the next seven numbers
        Assert.IsTrue(splitValues[1].SequenceEqual(Enumerable.Range(8, 7)));
        // the third set contains the last six
        Assert.IsTrue(splitValues[2].SequenceEqual(Enumerable.Range(15, 6)));
    }
