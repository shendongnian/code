    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using System.Linq;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            // Deserialize single instance
            XmlSerializer serializerSingle = new XmlSerializer(typeof(Universe));//, new XmlRootAttribute("document"));
            using (FileStream stream = File.OpenRead(@"<Path to your XML data>\planet.xml"))
            {
                // 'ReadXML.Xml2CSharp.Document' is the 'Document' class in your XML Classes
                Universe dezerializedXMLSingle = (Universe)serializerSingle.Deserialize(stream);
                var SubPlanets = (from p in dezerializedXMLSingle.Planet where p.Id == "fila7866" select p.Planets).ToList();
            } // Put a break-point here, then mouse-over dezerializedXMLSingle
        }
    }
    }
	[XmlRoot(ElementName="planet")]
	public class Planet {
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName="description")]
		public string Description { get; set; }
		[XmlElement(ElementName="planet")]
		public List<Planet> Planets { get; set; }
	}
	[XmlRoot(ElementName="Universe")]
	public class Universe {
		[XmlElement(ElementName="planet")]
		public List<Planet> Planet { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName="parentId")]
		public string ParentId { get; set; }
	}
