    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    
    public class Root
    {
        [JsonProperty("batchcomplete")]
        public string BatchComplete { get; set; }
        [JsonProperty("continue")]
        public Continuation Continuation { get; set; }
        [JsonProperty("query")]
        public Query Query { get; set; }
    }
    
    public class Continuation
    {
        [JsonProperty("grncontinue")]
        public string GrnContinue { get; set; }
        [JsonProperty("continue")]
        public string Continue { get; set; }
    }
    
    public class Query
    {
        [JsonProperty("pages")]
        public Dictionary<int, Page> Pages { get; set; }
    }
    
    public class Page
    {
        [JsonProperty("pageid")]
        public int Id { get; set; }
        [JsonProperty("ns")]
        public int Ns { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("extract")]
        public string Extract { get; set; }
    }
    
    class Test
    {
        static void Main()
        {
            string text = File.ReadAllText("test.json");
            var root = JsonConvert.DeserializeObject<Root>(text);
            Console.WriteLine(root.Query.Pages[16689396].Title);
        }    
    }
