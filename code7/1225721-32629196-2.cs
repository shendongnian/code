	[Serializable()]
	public class rootValues
	{
		public rootValues()
		{
			valuesArray = new List<values>(); 
		}
		[XmlElement("item", typeof(values))]
		public List<values> valuesList { get; set; }
	} 
	
	[Serializable()]
	public class values
	{
		[System.Xml.Serialization.XmlAttribute("ctrlname")]
		public string ctrlname { get; set; }
		
		//....
	} 
	
