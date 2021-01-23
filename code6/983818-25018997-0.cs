    public class ExcelSheet
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlArray]
        public List<Parameter> Query = new List<Parameter>();
        [XmlArray]
        public List<Parameter> Result = new List<Parameter>();
    }
