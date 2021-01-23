    class MyXmlWrapper
    {
        XElement _xml;
    
        public MyXmlWrapper(XElement xml)
        {
            _xml = xml;
        }
    
        public MyXmlWrapper this[string name]
        {
            get
            {
                return new MyXmlWrapper(_xml.Element(name));
            }
        }
    
        public static implicit operator string(MyXmlWrapper xml)
        {
            return xml._xml.Value;
        }
    }
