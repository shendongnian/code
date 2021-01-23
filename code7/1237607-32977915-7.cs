    using System;
    using System.Collections.Generic;
    using System.Net;
    using Newtonsoft.Json;
    
    namespace WebClientDownloadMp4
    {
        class Program
        {
            static void Main(string[] args)
            {
    			// Insert your key here
                var key = "0000000000000000000000000000";
    			
                var client = new WebClient();
                var reply = client.DownloadString(@"http://api.brewerydb.com/v2/adjuncts?key=" + key);
                var adjunctsReply = JsonConvert.DeserializeObject<AdjunctsReply>(reply);
                Console.WriteLine("Current page: " + adjunctsReply.currentPage);
                Console.WriteLine("Total pages: " + adjunctsReply.numberOfPages);
                Console.WriteLine("Total results: " + adjunctsReply.totalResults);
                foreach (var adjunct in adjunctsReply.Adjuncts)
                {
                    Console.WriteLine("Id {0}: {1}", adjunct.id, adjunct.name);
                }
            }
        }
    
        public class Adjunct
        {
            public int id { get; set; }
            public string name { get; set; }
            public string category { get; set; }
            public string categoryDisplay { get; set; }
            public string createDate { get; set; }
        }
    
        public class AdjunctsReply
        {
            public int currentPage { get; set; }
            public int numberOfPages { get; set; }
            public int totalResults { get; set; }
            [JsonProperty("data")]
            public List<Adjunct> Adjuncts { get; set; }
            public string status { get; set; }
        }
    }
