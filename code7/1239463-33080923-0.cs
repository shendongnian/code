    public static void WriteFullElementString(this XmlTextWriter writer, string localName, string value)
    {
        writer.WriteStartElement(localName);
        writer.WriteRaw(value);
        writer.WriteFu‌​llEndElement();
    }
