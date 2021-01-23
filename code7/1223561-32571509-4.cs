            [XmlType(Namespace="http://schemas.microsoft.com/windowsazure")]
            [XmlRoot(Namespace="http://schemas.microsoft.com/windowsazure")]        
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
            
            [XmlType(Namespace="http://schemas.microsoft.com/windowsazure")]
            [XmlRoot(Namespace="http://schemas.microsoft.com/windowsazure")]
            public class ServiceResources
            {
               [XmlElement("ServiceResource")]
               public List<ServiceResource> ServiceResource { get; set; }
            }
