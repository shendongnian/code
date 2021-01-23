    [Test]
    public void SomeTest()
    {
        var ee = Assert.Throws<CustomException>(() => p.SomeMethod());
        Assert.IsTrue(ee.StackTrace.Contains("Some expected text"));
    }
