    class Program
    {
        static void Main(string[] args)
        {
            // Set up a dummy object with some data. The object also has a bunch
            // of properties that are never set, so they have null values by default.
            Foo foo = new Foo
            {
                String = "test",
                Int = 123,
                Decimal = 3.14M,
                Object = new Bar { Name = "obj1" },
                Array = new Bar[]
                {
                    new Bar { Name = "obj2" }
                }
            };
            // The serializer writes to the custom NullJsonWriter, which
            // writes to the StringWriter, which writes to the StringBuilder.
            // We could also use a StreamWriter in place of the StringWriter
            // if we wanted to write to a file or web response or some other stream.
            
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            using (NullJsonWriter njw = new NullJsonWriter(sw))
            {
                JsonSerializer ser = new JsonSerializer();
                ser.Formatting = Formatting.Indented;
                ser.Serialize(njw, foo);
            }
            // Get the JSON result from the StringBuilder and write it to the console.
            Console.WriteLine(sb.ToString());
        }
    }
    class Foo
    {
        public string String { get; set; }
        public string NullString { get; set; }
        public int? Int { get; set; }
        public int? NullInt { get; set; }
        public decimal? Decimal { get; set; }
        public decimal? NullDecimal { get; set; }
        public Bar Object { get; set; }
        public Bar NullObject { get; set; }
        public Bar[] Array { get; set; }
        public Bar[] NullArray { get; set; }
    }
    class Bar
    {
        public string Name { get; set; }
    }
    public class NullJsonWriter : JsonTextWriter
    {
        public NullJsonWriter(TextWriter writer) : base(writer)
        {
        }
        public override void WriteNull()
        {
            base.WriteValue(string.Empty);
        }
    }
