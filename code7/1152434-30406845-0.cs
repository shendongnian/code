    class MyPoco
    {
        // CSV file must have a header with these property names.
        public int Foo { get; set; }
        public string Bar { get; set; }
        public DateTime Baz { get; set; }
    
        public static IEnumerable<MyPoco> FromStream(Stream stream)
        {
            return Ctl.Data.Formats.Csv.ReadObjects<MyPoco>(new StreamReader(stream));
        }
    }
