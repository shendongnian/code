	[Serializable]
	[XmlRoot("Import")]
	public class CaseList
	{
		[XmlElement("caseList")]
		public List<Cases> caseList
		{
			get;
			set;
		}
		public CaseList(List<Cases> caseItemList)
		{
			caseList = caseItemList;
		}
		public CaseList()
		{
		}
	}
