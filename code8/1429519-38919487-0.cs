        [Serializable]
        [XmlType]
        public class MyMessage
        {
            [XmlElement]
            public List<BaseClass> data;
        }
        [XmlInclude(typeof(SomeClass))]
        [XmlInclude(typeof(OtherClass))]
        [Serializable]
        public class BaseClass
        {
        }
        [Serializable]
        [XmlType(Namespace = "http://comp.com/types")]
        public class SomeClass : BaseClass
        {
            [XmlElement]
            public string SomeString { get; set; }
            [XmlElement]
            public int SomeInt { get; set; }
        }
        [Serializable]
        [XmlType(Namespace = "http://comp.com/types")]
        public class OtherClass : BaseClass
        {
            [XmlElement]
            public string OtherString { get; set; }
            [XmlElement]
            public int OtherInt { get; set; }
        }
