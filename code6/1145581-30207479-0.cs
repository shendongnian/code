    class TestableProvideBase : ProvideBase{}
    [TestMethod]
    public void TestTagProperty() {
        var sut = new TestableProvideBase();
        Assert.AreEqual(String.Empty, sut.Tag);
        sut.Tag = "someValue";
        Assert.AreEqual("someValue", sut.Tag);
    }
