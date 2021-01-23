    [Serializable]
    public class Foo
    {
       [XmlAttribute]
       public String NameWorking { get; set; }
       [XmlAttribute]
       public String TitleNotWorking { get; set; }
       ...
    }
