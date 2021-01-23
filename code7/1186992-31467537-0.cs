    [DataContract]
    class ClassToBeSerialized
    {
        public LinearGradientBrush Brush { get; set; }
        [DataMember(Name = "Brush")]
        private XamlSerializationWrapper<LinearGradientBrush> BrushSerializer
        {
            get { return new XamlSerializationWrapper<LinearGradientBrush>(Brush); }
            set { Brush = value.Element; }
        }
    }
    class XamlSerializationWrapper<TElement> : IXmlSerializable
    {
        public TElement Element { get; private set; }
        protected XamlSerializationWrapper()
        {
        }
        public XamlSerializationWrapper(TElement element)
        {
            this.Element = element;
        }
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            // this is a bit circuitous, but XamlReader.Load closes the reader for some reason
            var element = (XElement)XElement.ReadFrom(reader);
            Element = (TElement)XamlReader.Parse(element.Elements().Single().ToString());
        }
        public void WriteXml(XmlWriter writer)
        {
            XamlWriter.Save(Element, writer);
        }
    }
