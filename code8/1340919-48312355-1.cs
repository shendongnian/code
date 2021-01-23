    [TestMethod]        
    public void TestAssertOutput()
        {
            OutputAssert(() => Assert.AreEqual(false, true, "test message"));
        }
