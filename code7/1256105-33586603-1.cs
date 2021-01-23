    namespace UnitTestProject1
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                using (ShimsContext.Create())
                {
                    System.Security.Principal.Fakes.ShimWindowsIdentity.AllInstances.NameGet = (i) =>
                    {
                        return "Simon the hacker";
                    };
    
                    WindowsIdentity wi = WindowsIdentity.GetCurrent(); // this is the real one "Simon".
                    Thread.CurrentPrincipal = new WindowsPrincipal(wi);
    
                    Class1.MyCheck();
                }
            }
        }
    }
