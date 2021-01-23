    [XmlRoot("phrase")]
    public class Phrase
    {
      [XmlAttribute("level")]
      public int Level { get; set; }
      [XmlElement("subject")]
      public string Subject { get; set; }
      [XmlText]
      public string Value { get; set; }
    }
