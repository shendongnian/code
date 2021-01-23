    [TestClass]
    public class AuthenticatedTest
    {
      [TestInitialize]
      public void TestInitialize()
      {
        // login
      }
    }
    
    [TestClass]
    public class MyTests : AuthenticatedTest
    {
      [TestMethod]
      public void Whatever()
      {
        // already logged in.
      }
    }
