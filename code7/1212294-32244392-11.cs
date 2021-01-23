    public class SampleController : ApiController
    {
        [FaultExceptionFilter]
        public Contact SampleMethod(int id)
        {
           //Your call to a method throwing FaultException
            throw new FaultException<MyFaultDetail>("This method is not implemented");
        }
    }
