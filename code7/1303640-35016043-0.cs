    	[XmlRoot(ElementName="Komunikacja")]
    	public class Komunikacja {
    		[XmlElement(ElementName="Typ")]
    		public string Typ { get; set; }
    		[XmlElement(ElementName="Port")]
    		public string Port { get; set; }
    		[XmlElement(ElementName="BaudRate")]
    		public string BaudRate { get; set; }
    		[XmlElement(ElementName="Interval")]
    		public string Interval { get; set; }
    		[XmlElement(ElementName="Retry")]
    		public string Retry { get; set; }
    		[XmlElement(ElementName="TYPWAGI")]
    		public string TYPWAGI { get; set; }
    		[XmlElement(ElementName="RODZAJWAGI")]
    		public string RODZAJWAGI { get; set; }
    		[XmlElement(ElementName="PASEKPOSTEPU")]
    		public string PASEKPOSTEPU { get; set; }
    		[XmlElement(ElementName="DEBUGMESS")]
    		public string DEBUGMESS { get; set; }
    		[XmlElement(ElementName="AKCJA")]
    		public string AKCJA { get; set; }
    		[XmlElement(ElementName="TYPDANYCH")]
    		public string TYPDANYCH { get; set; }
    	}
    
    	[XmlRoot(ElementName="DEFAULT")]
    	public class DEFAULT {
    		[XmlAttribute(AttributeName="DEPARTMENT")]
    		public string DEPARTMENT { get; set; }
    		[XmlAttribute(AttributeName="PLUTYPE")]
    		public string PLUTYPE { get; set; }
    	}
    
    	[XmlRoot(ElementName="RECORD")]
    	public class RECORD {
    		[XmlAttribute(AttributeName="PLU")]
    		public string PLU { get; set; }
    		[XmlAttribute(AttributeName="NAZWA01")]
    		public string NAZWA01 { get; set; }
    		[XmlAttribute(AttributeName="UNITPRICE")]
    		public string UNITPRICE { get; set; }
    		[XmlAttribute(AttributeName="ITEMCODE")]
    		public string ITEMCODE { get; set; }
    		[XmlAttribute(AttributeName="GROUP")]
    		public string GROUP { get; set; }
    	}
    
    	[XmlRoot(ElementName="Dane")]
    	public class Dane {
    		[XmlElement(ElementName="RECORD")]
    		public List<RECORD> RECORD { get; set; }
    	}
    
    	[XmlRoot(ElementName="CAS_POLSKA")]
    	public class CAS_POLSKA {
    		[XmlElement(ElementName="Komunikacja")]
    		public Komunikacja Komunikacja { get; set; }
    		[XmlElement(ElementName="DEFAULT")]
    		public DEFAULT DEFAULT { get; set; }
    		[XmlElement(ElementName="Dane")]
    		public Dane Dane { get; set; }
    	}
    }
