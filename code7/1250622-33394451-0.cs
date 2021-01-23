    public class Serializator
    {
        public static string SerializeLinqList<T>(List<T> list)
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(List<T>));
            StringBuilder sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb))
            {
                dcs.WriteObject(writer, list);
            }
            return sb.ToString();
        }
     
        public static List<T> DeserializeLinqList<T>(string xml)
        {
            List<T> list;
     
            DataContractSerializer dcs = new DataContractSerializer(typeof(List<T>));
     
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                list = dcs.ReadObject(reader) as List<T>;
            }
            if (list == null) list = new List<T>();
            return list;
        }
    }
