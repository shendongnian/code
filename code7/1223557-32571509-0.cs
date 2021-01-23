        public class ServiceResource
        {
    
            public string Name { get; set; }
    
            public string Type { get; set; }
    
            public string State { get; set; }
    
            public string SelfLink { get; set; }
    
            public string ParentLink { get; set; }
    
            public string StartIPAddress { get; set; }
    
            public string EndIPAddress { get; set; }
        
        }
        
        public class ServiceResources
        {
           [XmlElement("ServiceResource")]
           public List<ServiceResource> ServiceResource { get; set; }
        }
