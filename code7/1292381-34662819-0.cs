    [TestClass]
    public class MyTestClass
    {
       // simply declare this property and the test framework will set it
       public TestContext TestContext {get; set;}
    
       [TestMethod]
       public void MyTestMethod()
       {
          //... your test code
          TestContext.WriteLine("Hey, I got some information for you");
          // more of your test code
       }
    }
