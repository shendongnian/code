    public class MyFactory : IFactory
    {
        public IIConsultationRepository Create()
        {
            return new ConsultationRepository();
        }
    }
    public class MyTestFactory : IFactory
    {
        public IIConsultationRepository Create()
        {
            return new ConsultationTestRpository();
        }
    }
