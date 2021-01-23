    namespace TypeNameHandlingTest
    {
        using System;
        using Newtonsoft.Json;
    
        public class Foo
        {
            public string Bar { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var foo = new Foo { 
                    Bar = "bar" 
                };
                var settings = new JsonSerializerSettings { 
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All 
                };
                var json = JsonConvert.SerializeObject(foo, settings);
    
                object deserialized = JsonConvert.DeserializeObject(json, settings);
                Console.WriteLine(deserialized.GetType().AssemblyQualifiedName);
                Console.ReadLine();
            }
        }
    }
