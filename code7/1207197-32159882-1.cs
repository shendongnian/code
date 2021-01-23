    class Program
    {
        static void Main(string[] args)
        {
            ParseAndDump(@"{ ""Date"" : ""2015-08-22T19:02:42Z"", ""Count"" : 40 }");
            ParseAndDump(@"{ ""Date"" : ""2015-08-20T15:55:04Z"", ""Customers"" : 26 }");
            ParseAndDump(@"{ ""Date"" : ""2015-08-21T10:17:31Z"", ""Replies"" : 35 }");
        }
        private static void ParseAndDump(string json)
        {
            DateAndCount dac = JsonConvert.DeserializeObject<DateAndCount>(json);
            Console.WriteLine("Date: " + dac.Date);
            Console.WriteLine("Count: " + dac.Count);
            Console.WriteLine();
        }
    }
    [JsonConverter(typeof(DateAndCountConverter))]
    class DateAndCount
    {
        public DateTime? Date { get; set; }
        public int Count { get; set; }
    }
