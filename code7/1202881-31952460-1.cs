    [TestMethod]
    public void PadTest()
    {
        Assert.AreEqual(string.Empty, "xyz".CustomPadLeft(0, '0'));
        Assert.AreEqual("xyz", "xyz".CustomPadLeft(2, '0'));
        Assert.AreEqual("00000abc", "abc".CustomPadLeft(8, '0'));
    }
