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
            // create a list that contains the items.
            var list = new List<SampleObjectSource>
            {
                new SampleObjectSource { MsfId= 100, PgId=  "abc", DcId= "123" },
                new SampleObjectSource { MsfId= 100, PgId=  "def", DcId= "456" },
                new SampleObjectSource { MsfId= 100, PgId=  "ghi", DcId= "789" },
                new SampleObjectSource { MsfId= 101, PgId=  "abc", DcId= "123" },
            };
            // the linq query that does the grouping.
            var query = from item in list
                        // group the items by MsfId
                        group item by item.MsfId into itemgroup
                        // create the new class and initialize the properties
                        select new SampleObject
                        {
                            // the grouping item is the .Key (in this case MsfId)
                            MsfId = itemgroup.Key,
                            // the itemgroup is a collection of all grouped items, so you need to select the properties you're interrested in.
                            DcId = itemgroup.Select(i => i.DcId).ToList(),
                            PgId = itemgroup.Select(i => i.PgId).ToList()
                        };
            // show the results in the Output window.
            foreach (var item in query)
            {
                Trace.WriteLine($"MsfId: {item.MsfId}");
                // some trick to format a list of strings to one string
                Trace.WriteLine($"PgId: {string.Join(", ", item.PgId.Select(s => Quote(s)))}");
                Trace.WriteLine($"DcId: {string.Join(", ", item.DcId.Select(s => Quote(s)))}");
                Trace.WriteLine("");
            }
        }
        // this method will surround the passed string with quotes.
        private string Quote(string item)
        {
            return "\"" + item + "\"";
        }
    }
