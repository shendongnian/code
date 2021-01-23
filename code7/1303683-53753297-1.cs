    [TestClass]
    public class Tests
    {
        [MyTestMethod]
        public void Test()
            => Assert.Fail("Some exception text");
    }
