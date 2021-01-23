    [TestMethod]
    public async Task Test()
    {
        IBar bar = GetMockedBarImpl();
        var sut = new Foo(await bar.GetStringsAsync());        
        
        Assert.IsTrue(sut.MyCollection.Any());
        // TODO: Add asserts for known strings in collection...
    }
