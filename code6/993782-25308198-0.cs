    using System;
    using System.IO;
    using Newtonsoft.Json.Linq;
    
    class Test
    {
        public static void Main(string[] args)
        {
            string text = File.ReadAllText("test.json");
            var json = JObject.Parse(text);
            
            foreach (var pair in json)
            {
                string id = pair.Key;
                bool value = (bool) pair.Value;
                Console.WriteLine("id: {0}; value: {1}", id, value);
            }
        }
    }
