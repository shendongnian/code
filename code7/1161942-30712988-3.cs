    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var objForTesting = new TheConsultationClass(new MyTestFactory());
            objForTesting.AddConsultation(...);
        }
    }
    
    
