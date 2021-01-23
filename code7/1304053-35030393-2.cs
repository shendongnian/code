    public static T DeserializeFromXml<T>(string xml)
    {
        try
        {
            T result;
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (TextReader tr = new StringReader(xml))
            {
                result = (T)ser.Deserialize(tr);
            }
            return result;
        }
        catch { throw; }
    }
