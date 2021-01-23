	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class recording
	{
		public string starttime { get; set; }
		public string endtime { get; set; }
		public string calldirection { get; set; }
		public string filename { get; set; }
		[XmlArray]
		[XmlArrayItem("recordingowner", IsNullable = false)]
		public byte[] recordingowners { get; set; }
		[XmlArrayItem("party", IsNullable = false)]
		public recordingParty[] parties { get; set; }
	}
	[XmlType(AnonymousType = true)]
	public class recordingParty
	{
		public string number { get; set; }
		public string pstarttime { get; set; }
		public string pendtime { get; set; }
		[XmlAttribute]
		public int id { get; set; }
	}
