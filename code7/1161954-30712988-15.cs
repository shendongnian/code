    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var objForTesting = new TheConsultationClass(new MyTestFactory());
            var consultationView = new ConsultationView();
            
            objForTesting.AddConsultation(consultationView, 123);
            var consultation = objForTesting.GetById(...);
            Assert.AreEqual(123, consultation.U_Id );
        }
    }
    
    
