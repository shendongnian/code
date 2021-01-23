	public class Check
	{
		//This constructor is needed, but .NET will create 
		//it automatically if no other constructors are defined
		public Check(){	} 
		
		public Guid? requestID { get; set; }
		public string barCode { get; set; }
	}
