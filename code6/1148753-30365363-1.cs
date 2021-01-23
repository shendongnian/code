    class Foo
    {
        public int Id { get; set; }
        public string SomeString { get; set; }
        public int? SomeInt { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var nullConverter=new NullReportConverter();
            Console.WriteLine("Pass 1");
            var obj0 = JsonConvert.DeserializeObject<Foo>("{\"Id\":5, \"Id\":5}", nullConverter);
            foreach(var p in nullConverter.NullProperties)
                Console.WriteLine(p);
            nullConverter.Clear();
            Console.WriteLine("Pass2");
            var obj1 = JsonConvert.DeserializeObject<Foo>("{\"Id\":5,\"SomeString\":null,\"SomeInt\":null}" , nullConverter);
            foreach (var p in nullConverter.NullProperties)
                Console.WriteLine(p);
            nullConverter.Clear();
            nullConverter.ReportDefinedNullTokens = true;
            Console.WriteLine("Pass3");
            var obj2 = JsonConvert.DeserializeObject<Foo>("{\"Id\":5,\"SomeString\":null,\"SomeInt\":null}", nullConverter);
            foreach (var p in nullConverter.NullProperties)
                Console.WriteLine(p);
        }
    }
