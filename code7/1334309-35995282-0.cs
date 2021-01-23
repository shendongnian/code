       /* 
        Licensed under the Apache License, Version 2.0
        
        http://www.apache.org/licenses/LICENSE-2.0
        */
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace Xml2CSharp
    {
    	[XmlRoot(ElementName="Y")]
    	public class Y {
    		[XmlAttribute(AttributeName="att")]
    		public string Att { get; set; }
    		[XmlText]
    		public string Text { get; set; }
    	}
    
    	[XmlRoot(ElementName="X")]
    	public class X {
    		[XmlElement(ElementName="Y")]
    		public List<Y> Y { get; set; }
    	}
    
    }
