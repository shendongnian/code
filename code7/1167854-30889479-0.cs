	[DataContract(Namespace = "http://schemas.datacontract.org/2004/07/appulsive.Intertek.LIMSService")]
	public class AddResult
	{
		[DataMember()]
		public string ErrorMessage;
		[DataMember()]
		public bool ResultStatus;
		[DataMember()]
		public string Result;
	}
