    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""identification"": {
                    ""lineItem/latestDate"": ""2013-04-28"",
                    ""lineItem/destination"": ""test"",
                    ""lineItem/quantity"": ""55"",
                }
            }";
            RootObject obj = JsonConvert.DeserializeObject<RootObject>(json);
            foreach (KeyValuePair<string, string> kvp in obj.identification)
            {
                Console.WriteLine("type: " + kvp.Key);
                Console.WriteLine("value: " + kvp.Value);
                Console.WriteLine();
            }
        }
    }
    class RootObject
    {
        public Dictionary<string, string> identification { get; set; }
    }
