    using Newtonsoft.Json.Bson;
    using Newtonsoft.Json;
    
     class Program
        {
            public class TestClass
            {
                public string Name { get; set; }
            }
    
            static void Main(string[] args)
            {
                string jsonString = "{\"Name\":\"Movie Premiere\"}";
                var jsonObj = JsonConvert.DeserializeObject(jsonString);
    
                MemoryStream ms = new MemoryStream();
                using (BsonWriter writer = new BsonWriter(ms))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(writer, jsonObj);
                }
    
                string data = Convert.ToBase64String(ms.ToArray());
    
                Console.WriteLine(data);
            }
        }
