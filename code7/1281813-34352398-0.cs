    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace MyNamespace
    {
    	[XmlRoot(ElementName="l_error")]
    	public class L_error {
    		[XmlElement(ElementName="error")]
    		public List<string> Error { get; set; }
    	}
    
    	[XmlRoot(ElementName="desc")]
    	public class Desc {
    		[XmlElement(ElementName="l_error")]
    		public L_error L_error { get; set; }
    	}
    
    }
