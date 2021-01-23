    [TestMethod]
    public void TestNonSequentialElements()
    {
        var data = new List<int> { 
            1, 3, 5, 7, 6, 8, 10, 2, 5, 8, 11, 11, 13 
        };
        EnumerateAndPrintResults(data);
    }
