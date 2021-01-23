    [TestClass]
    public class ApiTest
    {
         private static var x;
         [ClassInitialize()]
         public static void InitApiTest(TestContext context)
         {
             some operactons
             x = some value
         }
         [TestMethod]
         public testA()
         {
             //Obsolete
         }
         [TestMethod]
         public testB()
         {
             if(x == null)
                test fail
             else
                ...
         }
    }
