        [XmlRoot("Children")]
        public class Children
        {
            [XmlElement("Activity")]
            List<Activity> activity { get; set; }
            [XmlElement("Container")]
            List<Container> container { get; set; }
        }
        [XmlRoot("Activity")]
        public class Activity
        {
            
        }
        [XmlRoot("Container")]
        public class Container
        {
            
        }
