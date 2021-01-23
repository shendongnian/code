        [XmlInclude(typeof(class1))]
        [XmlInclude(typeof(class2))]
        [XmlInclude(typeof(class3))]
        [Serializable]
        [XmlRoot(ElementName = "event")]
        public class Event
        {
            [XmlElement("property1")]
            public ulong Property1 {get; set;}
            [XmlElement("property2")]
            public int Property2 { get; set; }
        }
        [Serializable]
        [XmlRoot(ElementName = "class1")]
        public class class1 : Event 
        {
            [XmlElement("property31")]
            public string Property31 { get; set; }
            [XmlElement("property32")]
            public string Property32 { get; set; }
            [XmlElement("property33")]
            public string Property33 { get; set; }
        }
        [Serializable]
        [XmlRoot(ElementName = "class2")]
        public class class2 : Event 
        {
            [XmlElement("property41")]
            public string Property41 { get; set; }
            [XmlElement("property42")]
            public int Property42 { get; set; }
        }
        [Serializable]
        [XmlRoot(ElementName = "class3")]
        public class class3 : Event
        {
            [XmlElement("property51")]
            public int Property51 { get; set; }
            [XmlElement("property52")]
            public string Property52 { get; set; }
            [XmlElement("property53")]
            public double Property53 { get; set; }
            [XmlElement("property54")]
            public string Property54 { get; set; }
        }​
