    [TestMethod]
    public void Test()
    {
        _mock.Setup(x => x.GetVersion())
             .Returns(() => new VersionData { Number = 1, Str = "1" });
        VersionData l1 = _mock.Object.GetVersion(); // OK
        l1.Number = 2;
        l1.Str = "2";
        VersionData l2 = _mock.Object.GetVersion();
        Assert.AreNotSame(l1, l2);//True as mock returns new instance
    }
