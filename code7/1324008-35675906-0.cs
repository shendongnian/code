    using System.Linq;   
    ...
    class Foo
    {
        public class ResponseLine
        {
            public Trace trace { get; set; }
        }
        public class Details
        {
           public string date { get; set; }
           public string level { get; set; }
           public string message { get; set; }
        }
    
        public class Trace
        {
            public Details details { get; set; }
            //context?
        }
    
        public void getJson()
        {
            string responseText = Connection.Request("api call");
            Console.WriteLine(responseText);
            
            // responseText is not valid JSON, need to split it by lines
            // before deserializing.
            var traces = responseText.Split('\n')
                .Where(l => !string.IsNullOrWhiteSpace())
                .Select(l => JsonConvert
                    .DeserializeObject<ResponseLine>(l))
                .ToList();
        }
    }
