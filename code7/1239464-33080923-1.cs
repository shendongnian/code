    public static void WriteFullElementString(this XmlTextWriter writer, string localName, string value)
    {
        writer.WriteStartElement(localName);
        writer.WriteCData(value);
        writer.WriteFu‌​llEndElement();
    }
