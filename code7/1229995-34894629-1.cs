    internal class WhitespaceXmlNodeReader : XmlNodeReader
    {
        public WhitespaceXmlNodeReader(XmlNode node)
            : base(node)
        {
        }
        public override XmlNodeType MoveToContent()
        {
            do
            {
                switch (NodeType)
                {
                    case XmlNodeType.Attribute:
                        MoveToElement();
                        goto case XmlNodeType.Element;
                    case XmlNodeType.Element:
                    case XmlNodeType.EndElement:
                    case XmlNodeType.CDATA:
                    case XmlNodeType.Text:
                    case XmlNodeType.EntityReference:
                    case XmlNodeType.EndEntity:
                    // This was added:
                    case XmlNodeType.SignificantWhitespace:
                        return NodeType;
                }
            } while (Read());
            return NodeType;
        }
    }
