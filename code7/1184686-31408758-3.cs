    private static bool HandleElement(XmlReader reader, XmlWriter writer)
    {
        if (reader.Name == "e")
        {
            writer.WriteElementString("element", "val1");
            reader.ReadOuterXml();
            return true;
        }
    
        return false;
    }
