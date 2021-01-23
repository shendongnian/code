	[XmlRoot("import")]
	public class Import
	{
		[XmlAttribute("xmlns_xsi")]
		public string XMLNS { get; set; }
		[XmlAttribute("xsi_noNamespaceSchemaLocation")]
		public string XMLNSLocation { get; set; }
		[XmlElement("creationDate")]
		public string CreationDate { get; set; }
		[XmlElement("hospitalCode")]
		public string HospitalCode { get; set; }
		[XmlElement("importCasesWithErrors")]
		public int ImportCasesWithErrors { get; set; }
		[XmlArray("caseList")]
		[XmlArrayItem("case")]
		public List<Cases> caseList { get; set; }
		//[XmlElement("masterData")]
		//public MasterData MasterData { get; set; }
		public Import(List<Cases> caseItemList)
		{
			caseList = caseItemList;
		}
		public Import()
		{
		}
	}
