    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var objForTesting = new TheConsultationClass(new MyTestFactory());
            var consultation1 = new ... 
            objForTesting.AddConsultation(consultation1 );
            var consultation2 = objForTesting.GetById(...);
            Assert.AreEqual("123", consultation2.X);
        }
    }
    
    
