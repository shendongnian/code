        [XmlRoot(ElementName = "ArrayOfFoo")]
        public class ArrayOfFoo
        {
           [XmlElement("Foo")]
           public List<Foo> foos { get; set;}
        }
        [XmlRoot(ElementName = "Foo")]
        public class Foo  
        {
           [XmlElement("FooString")]
           public string FooString {get;set;}
           [XmlElement("Bar")]
           public List<Bar> bar { get; set;}
        }
        [XmlRoot(ElementName = "Bar")]
        public class Bar  
        {
           [XmlElement("BarString")]
           public string barString { get; set; }
        }
        [XmlRoot(ElementName = "BarString")]
        public class BarString  
        {
           [XmlText]
           public string value { get; set; }
        }​
