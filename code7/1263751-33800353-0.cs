    public static T Deserialize<T>(string path)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            object result;
            using (FileStream reader = File.Open(path, FileMode.Open))
            {
                result = ser.Deserialize(reader);
            }
            return (T)result;
        }
