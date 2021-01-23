	[XmlRoot("rootObject", Namespace = "http://www.example.com/xmlschemas/nonStandardSchema")]
	public class RootObject
	{
		public static XmlSerializerNamespaces GetAdditionalNamespaces()
		{
			XmlSerializerNamespaces xsNS = new XmlSerializerNamespaces();
			 
	
			xsNS.Add("", "http://www.example.com/xmlschemas/nonStandardSchema");
			xsNS.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
	
			return xsNS;
		}
		
		[XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public string XSDSchemaLocation
		{
			get
			{
				return "http://www.example.com/xmlschemas/nonStandardSchema1.xsd";
			}
			set
			{
				// Do nothing - fake property.
			}
		}
		
		[XmlElement("Image")]
		public Object[] OtherSerializedObjects { get; set; }
	
		public RootObject()
		{
			OtherSerializedObjects = new Object[]{};
		}
	}   
