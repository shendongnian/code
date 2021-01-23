    using System;
    using System.Collections.Generic;
    using System.IO;
    
    using Newtonsoft.Json;
    
    class ReadRandom
    {
        [JsonProperty("Random")]
        public string Random { get; set; }
        
        [JsonProperty("Random2")]
        public string Random2 { get; set; }
    }
    
    class ReadRandomContainer
    {
        [JsonProperty("Result")]
        public Dictionary<string, ReadRandom> Result { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText("test.json");
            var container = JsonConvert.DeserializeObject<ReadRandomContainer>(json);
            Console.WriteLine(container.Result["1357"].Random);
        }
    }
