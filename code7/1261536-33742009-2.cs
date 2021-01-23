    public class MyObj
    {
        [XmlElement("prop1")]
        public string prop1 { get; set; }
    
        public XmlNode prop2 { get; set; }
    
        [XmlElement(ElementName = "prop3", IsNullable = true)]
        public string prop3 { get; set; }
    }
	var r = (MyObj)serializer.Deserialize(new StringReader(myXmlString));
	Console.WriteLine(r.prop2.OuterXml);
