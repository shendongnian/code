        class ExampleClass
        {
            public string StringProperty { get; set; }
            public int IntProperty { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var objects = new object[]
                {
                    new ExampleClass(),
                    new StringBuilder()
                };
    
                var json = JsonConvert.SerializeObject(objects, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
    
                Console.WriteLine(json);
    
                var deserializedObjects = JsonConvert.DeserializeObject(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
    
                foreach (var type in (object[])deserializedObjects)
                {
                    Console.WriteLine(type.GetType());
                }
                Console.ReadKey();
            }
        }
