    [XmlRoot("result")]
    public class Xml
    {
        [XmlElement("rowset")]
        public RowSet[] RowSets { get; set; }
    }
    
    public class RowSet
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        [XmlElement("row")]
        public Row[] Rows { get; set; }
    }
    
    public class Row
    {
        [XmlAttribute("accountKey")]
        public int AccountKey { get; set; }
    
        [XmlAttribute("description")]
        public string Description { get; set; }
    } 
