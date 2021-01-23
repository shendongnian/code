    static class SchemaConstants
    {
        public const string Namespace = "something";
    }
    [XmlType(Namespace = SchemaConstants.Namespace)]
    public class xmlDoc 
    {
        // case 1
        public string element1;
        public string element2;
        
        // case 2
        public string otherelement1;
        public child1 child1;
    }
    [XmlType(Namespace = SchemaConstants.Namespace)]
    public class child1
    {
        public string element3;
        public string element4;
    }
