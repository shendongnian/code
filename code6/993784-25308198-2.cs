    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    
    class Test
    {
        public static void Main(string[] args)
        {
            string text = File.ReadAllText("test.json");
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, bool>>(text);
            
            foreach (var pair in dictionary)
            {
                string id = pair.Key;
                bool value = pair.Value;
                Console.WriteLine("id: {0}; value: {1}", id, value);
            }
        }
    }
