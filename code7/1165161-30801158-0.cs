    namespace CSharp6.Tests
    {
      [TestClass]
      public class NameofTests
      {
        [TestMethod]
        public void Nameof_ExtractsName()
        {
          Assert.AreEqual<string>("NameofTests", nameof(NameofTests));
          Assert.AreEqual<string>("TestMethodAttribute",
            nameof(TestMethodAttribute));
          Assert.AreEqual<string>("TestMethodAttribute",
            nameof(
             Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute));
          Assert.AreEqual<string>("Nameof_ExtractsName",
            string.Format("{0}", nameof(Nameof_ExtractsName)));
          Assert.AreEqual<string>("Nameof_ExtractsName",
            string.Format("{0}", nameof(
            CSharp6.Tests.NameofTests.Nameof_ExtractsName)));
        }
      }
    }
