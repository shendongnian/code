    class Foo
    {
        public string Test { get; set; }
    }
    public static Stream ToStream(string str)
    {
        MemoryStream stream = new MemoryStream();
        StreamWriter writer = new StreamWriter(stream);
        writer.Write(str);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
    static void Main(string[] args)
    {
        var stream = Program.ToStream(@"{ ""Test"" : ""TesT"" }");
        using (var reader = new JsonTextReader(new StreamReader(stream)))
        {
            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Objects,
                NullValueHandling = NullValueHandling.Ignore
            };
            var obj = serializer.Deserialize(reader);
            //  We want to try deserialization without specifying an explicit type first,
            //  then see if the resulting type is compatible with the type that is expected
            //  from the Web API stack stream.
            //  If not, then we try to read it again using an explicit type
            //  (although it probably won't work anyway still :p)
            var test = obj.GetType().IsSubclassOf(typeof(Foo)) ? obj : serializer.Deserialize(reader, typeof(Foo));
        }
    
