    [Serializable]
    public class productName {
     public productName() { }
     [XmlText]
     public string Value {get; set;}
     
     [XmlAttribute]
     public string locale {get; set;}
    }
