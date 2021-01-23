    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
              ""result"": [
                {
                  ""upon_approval"": ""Proceed to Next Task"",
                  ""location"": {
                    ""display_value"": ""Corp-HQR"",
                    ""link"": ""https://satellite.service-now.com/api/now/table/cmn_location/4a2cf91b13f2de00322dd4a76144b090""
                  },
                  ""expected_start"": """"
                }
              ]
            }";
            DeserializeAndDump(json);
            Console.WriteLine(new string('-', 40));
            json = @"
            {
              ""result"": [
                {
                  ""upon_approval"": ""Proceed to Next Task"",
                  ""location"": """",
                  ""expected_start"": """"
                }
              ]
            }";
            DeserializeAndDump(json);
        }
        private static void DeserializeAndDump(string json)
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new List<JavaScriptConverter> { new ResultConverter() });
            RootObject obj = serializer.Deserialize<RootObject>(json);
            foreach (var result in obj.result)
            {
                Console.WriteLine("upon_approval: " + result.upon_approval);
                if (result.location != null)
                {
                    Console.WriteLine("location display_value: " + result.location.display_value);
                    Console.WriteLine("location link: " + result.location.link);
                }
                else
                    Console.WriteLine("(no location)");
            }
        }
    }
    public class RootObject
    {
        public List<Result> result { get; set; }
    }
    public class Result
    {
        public string upon_approval { get; set; }
        public Location location { get; set; }
        public string expected_start { get; set; }
    }
    public class Location
    {
        public string display_value { get; set; }
        public string link { get; set; }
    }
