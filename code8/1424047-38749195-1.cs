    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        [XmlAnyElement("Extension")]
        public XmlElement Extension { get; set; }
        public Book()
        {
            this.Extension = new XmlDocument().CreateElement("Extension");
        }
        public Book AddExtension()
        {
            string innerXmlString = "<AdditionalInfo xmlns=\"http://www.somenamespace.com\">" +
                                    "<SpecialHandling>Some Value</SpecialHandling>" +
                               "</AdditionalInfo>";
            if (Extension == null)
                // Since Extension is marked with [XmlAnyElement("Extension")], its value must
                // be an XmlElement named "Extension".  Its InnerXml can be anything.
                Extension = new XmlDocument().CreateElement("Extension");
            Extension.InnerXml = innerXmlString;
            return this;
        }
        const string ModifierName = "Modifier";
        [XmlIgnore]
        public string Modifier
        {
            get
            {
                if (Extension == null)
                    return null;
                return Extension.GetAttribute(ModifierName);
            }
            set
            {
                if (Extension == null)
                    AddExtension();
                if (value == null)
                    Extension.RemoveAttribute(ModifierName);
                else
                    Extension.SetAttribute(ModifierName, value);
            }
        }
    }
