	public class Check
	{
		//This constructor is needed, but .NET will create 
		//it automatically if no other constructors are defined
		public Check() { }
        private Guid? requestID;
        private string barCode;
        public Guid? RequestId
        {
            get { return requestID; }
            set { requestID = value; }
        }
        public string BarCode
        {
            get { return barCode; }
            set { barCode = value; }
        }
	}
