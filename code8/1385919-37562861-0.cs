    // The class to start with
    public class SampleObjectSource
    {
        public int MsfId { get; set; }
        public string PgId { get; set; }
        public string DcId { get; set; }
    }
    // the result class
    public class SampleObject
    {
        public int MsfId { get; set; }
        public List<string> PgId { get; set; }
        public List<string> DcId { get; set; }
    }
    // for example:
    public class Example
    {
        public Example()
        {
            var list = new List<SampleObjectSource>
            {
                new SampleObjectSource { MsfId= 100, PgId=  "abc", DcId= "123" },
                new SampleObjectSource { MsfId= 100, PgId=  "def", DcId= "456" },
                new SampleObjectSource { MsfId= 100, PgId=  "ghi", DcId= "789" },
                new SampleObjectSource { MsfId= 101, PgId=  "abc", DcId= "123" },
            };
            var query = from item in list
                        group item by item.MsfId into itemgroup
                        select new SampleObject
                        {
                            MsfId = itemgroup.Key,
                            DcId = itemgroup.Select(i => i.DcId).ToList(),
                            PgId = itemgroup.Select(i => i.PgId).ToList()
                        };
            foreach (var item in query)
            {
                Trace.WriteLine($"MsfId: {item.MsfId}");
                Trace.WriteLine($"PgId: {string.Join(", ", item.PgId.Select(s => Quote(s)))}");
                Trace.WriteLine($"DcId: {string.Join(", ", item.DcId.Select(s => Quote(s)))}");
                Trace.WriteLine("");
            }
        }
        private string Quote(string item)
        {
            return "\"" + item + "\"";
        }
    }
