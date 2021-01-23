    [Test]
    public static void GetSortedIntegersTest()
    {           
        var first = new List<int>() { 0 };
        var second = new List<int>() { 1, 2 };
        var expected = new List<int>{ 0, 1, 2 };
        var actual = GetSortedIntegers(first, second);
        CollectionAssert.AreEqual(expected, actual.ToList());
    }
