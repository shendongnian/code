    [TestMethod]
    public void TestManagerPropertyRoundTrip {
        var sut = new TestableManager();
        Assert.IsNull(sut.empManager);
        sut.empManager = sut;
        Assert.AreEqual(sut, sut.empManager);
    }
