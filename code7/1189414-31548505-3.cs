    public class CustomSerializer
    {
        public static void Test()
        {
            var obj = new CustomString {Value = "Random string!"};
            var serializer = new CustomSerializer();
            var xml = serializer.Serialize(obj);
            Console.WriteLine(xml);
            var obj2 = serializer.Deserialize<CustomString>(xml);
        }
        public string Serialize(object obj)
        {
            var serializer = new XmlSerializer(obj.GetType());
            using (var io = new StringWriter())
            {
                serializer.Serialize(io, obj);
                return io.ToString();
            }
        }
        public T Deserialize<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof (T));
            using (var io = new StringReader(xml))
            {
                return (T)serializer.Deserialize(io);
            }
        }
    }
