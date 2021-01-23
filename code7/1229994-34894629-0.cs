    public virtual XmlNodeType MoveToContent() {
        do {
            switch (this.NodeType) {
                case XmlNodeType.Attribute:
                    MoveToElement();
                    goto case XmlNodeType.Element;
                case XmlNodeType.Element:
                case XmlNodeType.EndElement:
                case XmlNodeType.CDATA:
                case XmlNodeType.Text:
                case XmlNodeType.EntityReference:
                case XmlNodeType.EndEntity:
                    return this.NodeType;
            }
        } while (Read());
        return this.NodeType;
    }
