    [XmlRoot(ElementName = "NewDataSet", Namespace = "")]
    public class NewDataSet
    {
       [XmlElement("Table1")]
        public List<Table1> Table1{get; set;}
    }
    public class Table1
    {
        public string ID {get; set;}
        public string Name {get; set;}
        
    }
