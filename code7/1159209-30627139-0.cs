    [TestMethod]
    public void TestA()
    {
      var result = TestI32(arg1, arg2);
      Assert.IsTrue(result); // or whatever your assertion is.
    }
    
    [TestMethod]
    public void TestB()
    {
      var result = TestI32(arg3, arg4);
      Assert.IsFalse(result); // or whatever your assertion is.
    }
