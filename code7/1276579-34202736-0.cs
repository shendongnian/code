    using System;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    
    class Example
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText("test.json");
            var root = JObject.Parse(json);        
            var profile = (JObject) root["Profile"];
            var map = profile.Properties()
                             .ToDictionary(p => p.Name, p => p.Value.ToObject<Example>());
            foreach (var entry in map)
            {
                Console.WriteLine($"Key: {entry.Key}; Name: {entry.Value.Name}; Age: {entry.Value.Age}");
            }
        }
    }
