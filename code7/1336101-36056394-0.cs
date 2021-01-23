    [XmlRoot("root")]
    class Person : IXmlSerializable
    {
    	[XmlAttribute("name")]
    	public string Name {get;set;}
    	
    		public System.Xml.Schema.XmlSchema GetSchema() {
    			return null;
    		}
    
    		public void ReadXml( XmlReader reader ) {
    		...
    		}
    
    		public void WriteXml( XmlWriter writer ) {
    			writer.WriteStartElement( "root" );
    			writer.WriteStartElement( "general", null );
    			writer.WriteAttributeString( "action", Action );
    			...
    			writer.WriteEndElement();
    			writer.WriteEndElement();
    		}
    }
