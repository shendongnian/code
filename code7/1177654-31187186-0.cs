        [XmlRoot("mainDatas")]
        public partial class MainDatas
        {
            
            [XmlElement("Contains")]
            public MainDatasContains contains {get; set;}
        }
        [XmlRoot("Contains")]
        public partial class MainDatasContains
        {
            [XmlAttribute("id")]
            public string id { get; set; }
            [XmlElement("FeatureCollection")]
            public FeatureCollection featureCollection {get;set;}
        }
        [XmlRoot("FeatureCollection")]
        public partial class FeatureCollection
        {
            [XmlElement("boundedBy")]
            public double boundedBy { get; set; }
            [XmlElement("featureMember")]
            public List<FeatureMember> featureMembers {get; set;}
        }
        [XmlRoot("featureMember")]
        public class FeatureMember
        {
            [XmlElement("myClass1")]
            public MyClass1 myClass1 { get; set; }
            [XmlElement("myClass2")]
            public MyClass2 myClass2 { get; set; }
        }
        [XmlRoot("myClass1")]
        public class MyClass1
        {
            [XmlAttribute("id")]
            public string id { get; set; }
        }
        [XmlRoot("myClass2")]
        public class MyClass2
        {
            [XmlAttribute("id")]
            public string id { get; set; }
        }
