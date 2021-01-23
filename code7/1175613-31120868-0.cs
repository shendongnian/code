    [TestMethod]
    public void TestMethod_Test()
    {
        string value = "myValue";
        string regex = "&#@<>\s\\\$\(\)";
        var result = ClassContainingTest.Test(value, regex); 
        Assert.AreEqual(false, result);
    }
