    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft;
    using Newtonsoft.Json.Linq;
    
    namespace ConsoleApplication1
    {
    
        public class Metadata
        {
            public string Name { get; set; }
            public Guid Id { get; set; }
        }
    
        public class Root
        {
            public List<Metadata> listOfMetadata{get;set;}
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Run run = new Run();
                run.SerializeCars();
            }
        }
    
        public class Run
        {
            public void SerializeCars()
            {
                var root = new Root()
                {
                    listOfMetadata = new List<Metadata>()
                    {
                        new Metadata
                        { 
                            Name = "MyName", Id = Guid.NewGuid()
                        }
                    }
                };
    
                var json = JsonConvert.SerializeObject(root, Formatting.Indented);
                json = json.Replace("\"listOfMetadata\": ", string.Empty);
                Console.WriteLine(json);
                Console.ReadKey();
            }
        }
    }
