    public static object DeserializeFromXmlFile(this object obj, string FileName)
    {
        try
        {
            using (TextReader reader = new StreamReader(FileName))
            {
                XmlSerializer ser = new XmlSerializer(obj.GetType());
                return ser.Deserialize(reader);
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }
