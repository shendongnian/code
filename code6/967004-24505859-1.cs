        public class MyDataClass 
        {    
            // only one Property here, as there's only one root element in the xml
            // and this single Property is not bound to a specific XML element
            [XmlAnyElement]    
            public PropertyA PropertyA { get ;set; }
        }
