    [XmlClass(Namespace = "http://schemas.datacontract.org/2004/07/ConsoleApplication6")]
    public class Test
    {
        [XmlArray("values")]
        [XmlArrayItem("String")]
        public String[] values;
    }
