        public class JSONCookie
        {
            public Package[] package { get; set; }
            public Hotel[] hotel { get; set; }
            public Activity[] activity { get; set; }
        }
    
        public class Package
        {
            public string id { get; set; }
            public string nodeId { get; set; }
        }
    
        public class Hotel
        {
            public string id { get; set; }
            public string nodeId { get; set; }
        }
    
        public class Activity
        {
            public string id { get; set; }
            public string nodeId { get; set; }
        }
