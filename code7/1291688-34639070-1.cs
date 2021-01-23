    class MyXmlWrapper
    {
        XElement _xml;
    
        public MyXmlWrapper(XElement xml)
        {
            _xml = xml;
        }
    
        public MyXmlWrapper this[string name, int index = 0]
        {
            get
            {
                return new MyXmlWrapper(_xml.Elements(name).ElementAt(index));
            }
        }
    
        public static implicit operator string(MyXmlWrapper xml)
        {
            return xml._xml.Value;
        }
    }
