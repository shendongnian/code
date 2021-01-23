    public class TableName
    {
        public Students students { get; set; }
    }
    [XmlRoot(ElementName = "students")]
    public class Students
    {
        [XmlElement(ElementName = "row")]
        public List<Row> Rows { get; set; }
    }
    public class Row
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string Password { get; set; }
    }
    var ser = new XmlSerializer(typeof(TableName));
    var def = new XmlSerializerNamespaces();
    def.Add("", "");
    var obj = ser.Deserialize("xmlPath");
    
