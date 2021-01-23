    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    ...
    [XmlRoot("countries",  Namespace="")]
    public class countriesDocument
    {
        [XmlElement("country")]
        public country[] countries { get; set; }
    }
    public class country
    {
        [XmlText]
        public string name { get; set; }
        [XmlAttribute]
        public string code { get; set; }
        [XmlAttribute]
        public int iso { get; set; }
    }
