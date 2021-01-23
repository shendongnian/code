    [TestClass]
    public class UnitTest1
    {
        Sample.Class1 instance;
        [TestInitialize]
        public void InitTests()
        {
            instance = new Sample.Class1();
        }
        [TestMethod]
        public void TestMethod1()
        {
            var result = instance.FormatSpecial(5.25);
            Assert.AreEqual("5.3", result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("es-ES");
            var result = instance.FormatSpecial(5.25);
            Assert.AreEqual("5,3", result);
        }
    }
