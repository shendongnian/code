    namespace Q38072488.Xml
    {
      using System;
      using System.Xml.Serialization;
      [Serializable()]
      [XmlRoot("root", Namespace = "", IsNullable = false)]
      public partial class CDATA_TEXT
      {
        [XmlElement("text")]
        public string Text { get; set; }
      }
    }
