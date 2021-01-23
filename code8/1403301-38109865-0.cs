	[Serializable]
	public class SubClass : IXmlSerializable
	{
		[XmlElement("XmlConfiguration")]
		public string XmlConfiguration { get; set; }
	
		public void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement("XmlConfiguration");
			writer.WriteRaw(XmlConfiguration);
			writer.WriteEndElement();
		}
	
		public void ReadXml(XmlReader reader)
		{
			reader.ReadToDescendant("XmlConfiguration");
			XmlConfiguration = reader.ReadInnerXml();
			reader.ReadEndElement();
		}
	
		public XmlSchema GetSchema()
		{
			return (null);
		}
	}
