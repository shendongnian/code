    namespace Test
    {
        namespace WebService
        {
            [ServiceContract]
            public interface ITestService
            {
                 [OperationContract]
                 IList<Test> GetTest();
            }
        }
    }
