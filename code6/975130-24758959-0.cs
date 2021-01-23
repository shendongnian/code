    [TestMethod]
    public async void FourDividedByTwoIsTwoAsync()
    {
        int result = await MyClass.Divide(4, 2);
        Assert.AreEqual(2, result);
    }
