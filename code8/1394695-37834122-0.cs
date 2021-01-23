    [Test]
    public void GetSafeCount_NonICollectionObject_ReturnCount()
    {
        IEnumerable<string> enumerable = new string[0].Where(x => x.Length == 0);
        Assert.AreEqual(0, enumerable.GetSafeCount());
    }
