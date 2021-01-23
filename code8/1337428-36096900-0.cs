    public class FileSystem
    {
        public static void SerializeToFile<T>(T toSerialize, string fileName)
        {
            XmlSerializer writer = new XmlSerializer(typeof(T));
            StreamWriter file = new StreamWriter(fileName);
            writer.Serialize(file, toSerialize);
            file.Close();
        }
        public static T OpenSerialized<T>(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StreamReader reader = new StreamReader(fileName);
            object something = serializer.Deserialize(reader);
            return (T)something;
        }
    }
