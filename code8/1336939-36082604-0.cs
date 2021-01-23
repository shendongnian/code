    public class MyClass
    {
        [XmlArray("PersonList")]
        [XmlArrayItem("Person")]
        public List<Data> DataList { get; set; }
    }
    
    public class Data
    {
        public string Name { get; set; }
    }
