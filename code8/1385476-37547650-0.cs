	{
		List<Cases> caseItemList = new List<Cases>();
		Cases case1 = new Cases();
		case1.InternalPatientId = "sdfsdfsdfsdfsdf";
		case1.PatientCode = "sdf";
		caseItemList.Add(case1);
		Cases case2 = new Cases();
		case2.InternalPatientId = "123654654";
		case2.PatientCode = "654654";
		caseItemList.Add(case2);
		Import import = new Import(caseItemList);
		import.XMLNS = "http://www.w3.org/2001/XMLSchema-instance";
		import.XMLNSLocation = "TR-DGU%20Import-Schema%20V2015%20-%20Stand%20M%C3%A4rz%202016.xsd";
		import.CreationDate = "2016-05-19";
		import.HospitalCode = "A-0000-A";
		import.ImportCasesWithErrors = 1;
		var s = new System.Xml.Serialization.XmlSerializer(import.GetType());
		s.Serialize(Console.Out, import);
	}
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
	public class Cases
	{
		[XmlElement("patientCode")]
		public string PatientCode { get; set; }
		[XmlElement("internalPatientId")]
		public string InternalPatientId { get; set; }
		public Cases()
		{
		}
	}
