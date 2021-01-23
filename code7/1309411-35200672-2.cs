	public class Bill 
    {
        [System.Xml.Serialization.XmlElement("DocNo")]
        [XmlElementAttribute(Order = 1)] 
        public string DocNo { get; set; }
		......
	}
	
