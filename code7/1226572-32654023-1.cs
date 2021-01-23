    [TestMethod]
    public void TestBar()
    {
         var bar = new Bar();
         var result = bar.DoSomething();
         Assert.IsFalse(result, "This should fail");
         //I assume that this is your logic.
         Assert.IsTrue(bar.Messages.Contains("Hello World"));
    }
