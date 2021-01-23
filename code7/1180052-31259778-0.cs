    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace Xml2CSharp
    {
    	[XmlRoot(ElementName="item")]
    	public class Item {
    		[XmlAttribute(AttributeName="cur1")]
    		public string Cur1 { get; set; }
    		[XmlAttribute(AttributeName="cur2")]
    		public string Cur2 { get; set; }
    		[XmlText]
    		public string Text { get; set; }
    	}
    
    	[XmlRoot(ElementName="rates")]
    	public class Rates {
    		[XmlElement(ElementName="item")]
    		public List<Item> Item { get; set; }
    		[XmlAttribute(AttributeName="date")]
    		public string Date { get; set; }
    	}
    
    	[XmlRoot(ElementName="result")]
    	public class Result {
    		[XmlElement(ElementName="rates")]
    		public Rates Rates { get; set; }
    		[XmlAttribute(AttributeName="xsi", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string Xsi { get; set; }
    		[XmlAttribute(AttributeName="schemaLocation", Namespace="http://www.w3.org/2001/XMLSchema-instance")]
    		public string SchemaLocation { get; set; }
    	}
    }
