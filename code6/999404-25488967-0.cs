    using System;
    using System.Text;
    using Newtonsoft.Json;
    namespace JsonTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string str = "Testing";
    
                Foo foo = new Foo
                {
                    UpdateSeq = Encoding.UTF8.GetBytes(str)
                };
    
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    Formatting = Formatting.Indented
                };
    
                string json = JsonConvert.SerializeObject(foo, settings);
                Console.WriteLine(json);
    
                Foo foo2 = JsonConvert.DeserializeObject<Foo>(json, settings);
                string str2 = Encoding.UTF8.GetString(foo2.UpdateSeq);
                Console.WriteLine();
                Console.WriteLine(str == str2 
                                  ? "strings are equal" 
                                  : "strings are NOT equal");
            }
        }
    
        public class Foo
        {
            public byte[] UpdateSeq { get; set; }
        }
    }
