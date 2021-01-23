    public static T DeserializeFromXmlFile<T>(string FileName) where T:class
    {
        try
        {
            using (TextReader reader = new StreamReader(FileName))
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                return ser.Deserialize(reader) as T;
            }
        }
        catch (Exception ex)
        {
            return default(T); // is this really the right approach?  Just ignore the error and silently return null?
        }
    }
