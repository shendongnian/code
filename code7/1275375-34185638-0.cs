    [Serializable]
	public class Document {
		public BinaryObject Binary { get; set; }
	}
	[Serializable]
	public class BinaryObject {
		[XmlText]
		public byte[] Binary { get; set; }
		[XmlAttribute]
		public int AddAttribute { get; set; }
		
        // Adds the dt:dt object to the correct name space.
		[XmlAttribute("dt", Namespace = "urn:schemas-microsoft-com:datatypes")]
		public string DataType { get; set; }
		
		public BinaryObject() { DataType = "bin.base64"; }
	}
	
	
	public class XmlExample {
		public static void Main(string[] args)
		{
			XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            
            // Adds the needed namespace to the document.
            namespaces.Add("dt", "urn:schemas-microsoft-com:datatypes");
			
			Document document = new Document();
			document.Binary = new BinaryObject();
			document.Binary.Binary = new byte[]{0,1,2,3,4,5,6,7,8,9};
			document.Binary.AddAttribute = 0;
			
			XmlSerializer serializer = new XmlSerializer(typeof(Document));
			
			serializer.Serialize(Console.Out, document, namespaces);
			Console.ReadLine();
		}
	}
