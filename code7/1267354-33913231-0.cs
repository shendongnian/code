    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace Xml2CSharp
    {
    	[XmlRoot(ElementName="Books")]
    	public class Books {
    		[XmlElement(ElementName="Title")]
    		public List<string> Title { get; set; }
    		[XmlElement(ElementName="Author")]
    		public List<string> Author { get; set; }
    	}
    
    }
