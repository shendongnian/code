    [DataContract(Namespace=Namespaces.V1)]
	public class MyFaultException
	{
		[DataMember]
		public string Reason { get; set; }
		public MyFaultException()
		{
			this.Reason = "Service encountered an error";
		}
		public MyFaultException(string reason)
		{
			this.Reason = reason;
		}
	}
