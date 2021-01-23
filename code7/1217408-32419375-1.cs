    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            [
                {
                    ""Value"" : ""foo bar"",
                    ""Type"" : ""String""
                },
                {
                    ""Value"" : 3.14,
                    ""Type"" : ""Real""
                },
                {
                    ""Value"" : 
                    {
                        ""Something"" : ""Test"",
                        ""Items"" : [""A"", ""B"", ""C""]
                    },
                    ""Type"" : ""JsonData""
                },
                {
                    ""Value"" : 42,
                    ""Type"" : ""Integer""
                }
            ]";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            jss.RegisterConverters(new List<JavaScriptConverter> { new JsonObjectConverter() });
            List<JsonObject> list = jss.Deserialize<List<JsonObject>>(json);
            foreach (JsonObject item in list)
            {
                Console.WriteLine(string.Format("({0}) {1}", item.Type, item.Value));
            }
        }
    }
    public class JsonObject
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
