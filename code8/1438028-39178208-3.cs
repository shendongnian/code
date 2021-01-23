    public class Program
    {
        static void Main(string[] args)
        {
            var s = "[{\"name\": \"Field1\", \"results\": [\"One\", \"Two\", \"Three\"]}, {\"name\": \"Field2\", \"results\": [\"One\", \"Two\", \"Three\", \"Four\"]}]";
            var o = JsonConvert.DeserializeObject<List<Output>>(s);
            // convert the list to a DataTable
            var dt = o.ToDataTable();
        }
        
        public class Output
        {
            public string name { get; set; }
            public string[] results { get; set; }
        }
    }
