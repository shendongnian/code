    namespace Test.WebService
    {
        //other using
        using TestBL;
    
        [ServiceContract]
        public interface ITestService
        {
             [OperationContract]
             IList<Test> GetTest();
        }
    }
