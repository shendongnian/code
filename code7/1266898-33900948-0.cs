    public void WriteXml(XmlWriter writer)
    {
        foreach (TKey key in this.Keys)
        {
            writer.WriteStartElement("Option");
            writer.WriteElementString("key", key.ToString());
            TValue value = this[key];
            writer.WriteElementString("value", value.ToString());
                
            writer.WriteEndElement();
        }
    }
