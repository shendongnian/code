    class MyPoco
    {
        // CSV file must have a header with these property names.
        public int Foo { get; set; }
        public string Bar { get; set; }
        public DateTime Baz { get; set; }
    
        public static IEnumerable<MyPoco> Read(CloudBlockBlob blob)
        {
            using(Stream s = blob.OpenRead())
            using(StreamReader sr = new StreamReader(s))
            {
                foreach(MyPoco x in Ctl.Data.Formats.Csv.ReadObjects<MyPoco>(sr))
                {
                    yield return x;
                }
            }
        }
    }
