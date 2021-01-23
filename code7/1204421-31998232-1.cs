    public class POREPORTSROW
	{
		public int PO_REPORT_PARAMETER_ID { get; set; }
		public string DESCRIPTION { get; set; }
	}
	public class POREPORTS
	{
		public POREPORTSROW PO_REPORTS_ROW { get; set; }
	}
	public class ROW
	{
		public int A_ONLINE_PO_COUNT { get; set; }
		public int A_OFFLINE_PO_COUNT { get; set; }
		public int A_NEW_MESSAGE_COUNT { get; set; }
		public int A_PASSWORD_EXPIRE_DAYS { get; set; }
		public POREPORTS PO_REPORTS { get; set; }
		public string RECV_REPORTS { get; set; }
		public string BUDGET_REPORTS { get; set; }
		public string VARIANCE_REPORTS { get; set; }
	}
	public class ROWSET
	{
		public ROW ROW { get; set; }
	}
	public class RootObject
	{
		public ROWSET ROWSET { get; set; }
	}
