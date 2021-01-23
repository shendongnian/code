    class Program
    {
        static void Main(string[] args)
        {
            SerializationFormat obj = new SerializationFormat
            {
                metadata = new MyMetaData { foo = "xyz", bar = 12 },
                data = new byte[] { 0x48, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x57, 0x6f, 0x72, 0x6c, 0x64, 0x21 }
            };
            using (Stream stream = new FileStream(@"c:\temp\test.json", FileMode.Create))
            using (TextWriter textWriter = new StreamWriter(stream, Encoding.UTF8))
            using (JsonWriter jsonWriter = new JsonTextWriter(textWriter))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jsonWriter, obj);
            }
        }
    }
    public class SerializationFormat
    {
        public MyMetaData metadata { get; set; }
        public byte[] data { get; set; }
    }
 
    public class MyMetaData
    {
        public string foo { get; set; }
        public int bar { get; set; }
    }
