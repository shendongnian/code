    [Test]
    public void TestMethod()
    {
        var test = new YourClass();
        test.IsValidFile();
        bool isValid = TestHelper.InvokeMethod(test, "IsValidCheksum", "pathTofile", "receivedChecksum");
        Assert.That(isValid, Is.True);
    }
