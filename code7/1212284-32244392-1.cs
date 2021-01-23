    public class SampleController : ApiController
    {
        [FaultExceptionFilter]
        public Contact SampleMethod(int id)
        {
            throw new FaultException<MyFaultDetail>("This method is not implemented");
        }
    }
