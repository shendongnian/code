    [TestMethod]
    public async Task Test()
    {
        var sut = new Foo();
        IBar bar = GetMockedBarImpl();
        await sut.AddConent(bar)
        
        Assert.IsTrue(sut.MyCollection.Any());
        // TODO: Add asserts for known strings in collection...
    }
