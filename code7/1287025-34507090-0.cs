    using System;
    using System.IO;
    using Newtonsoft.Json.Linq;
    
    public class Test
    {
        static void Main()
        {
            var json = File.ReadAllText("test.json");
            var obj = JObject.Parse(json);
            var valueArray = (JArray) obj["value"];
            // Note: if the array contains non-objects,
            // this will fail
            foreach (JObject value in valueArray)
            {
                Console.WriteLine("Values:");
                foreach (var property in value.Properties())
                {
                    Console.WriteLine("  {0}: {1}", property.Name, property.Value);
                }
            }
        }
    }
