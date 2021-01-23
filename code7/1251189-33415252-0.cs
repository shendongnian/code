        using (XmlWriter writer = XmlWriter.Create(stream, writerSettings))
        {
            string s = AntiXssEncoder.XmlEncode("€");
            writer.WriteStartElement("test");
            writer.WriteRaw(s);
            writer.WriteEndElement();
        }
