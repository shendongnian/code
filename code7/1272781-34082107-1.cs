	[ServiceContract]
    public class ABCService
    {
		[OperationContract]
        public Message OperationA()
	
		[OperationContract]
        public Message OperationB()
       [OperationContract]
        public Message OperationC()
	}
	
	[ServiceContract]
    public class ABService
    {
		[OperationContract]
        public Message OperationA()
	
		[OperationContract]
        public Message OperationB()
	}
