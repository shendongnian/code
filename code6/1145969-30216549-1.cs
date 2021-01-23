    [DataContract]
    public class MyExceptionClass
    {
	    [DataMember]
	    public Exception Exc { get; set; }
    }
	
	[ServiceContract]
    public interface ISystemInfoService
    {
        [OperationContract]
        [FaultContract(typeof(MyExceptionClass))]
        void DoThrowException(string message);
    }
	
	public class SystemInfoService : ISystemInfoService
    {
        public void DoThrowException(string message)
        {
            try
            {
                throw new Exception("MyMessage");
            }
            catch (Exception exc)
            {
			    var data = new MyExceptionClass { Exc = exc };
                throw new FaultException<MyExceptionClass>(data);
            }
        }
    }
