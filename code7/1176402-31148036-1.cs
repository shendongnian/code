    [Serializable]
    public class Foo
    {
       [XmlElement]
       public String NameWorking { get; set; }
       [XmlElement]
       public String TitleNotWorking { get; set; }
       ...
    }
