    public class ModelResource
    {
        public Models Models { get; set; }
    }
    
    [XmlInclude(typeof(MyChildClass))]
    [XmlRoot(Namespace = "")]
    public abstract class Models
    {
    }
    [XmlType("myChildClass", Namespace = "http://www.example.com/otSpace")]
    public class MyChildClass : Models
    {
        [XmlText]
        public string Value { get; set; }
    }
