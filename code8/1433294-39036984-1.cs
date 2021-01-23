    namespace StackOverflow.Test
    {
        using Newtonsoft.Json;
        using System;
        using System.Collections.Generic;
        using System.Linq;
    
        class Program
        {
            static void Main(string[] args)
            {
                var json = "{\n  \"data\": [\n    {\n      \"listid\": \"123\",\n      \"name\": \"Name\"\n    }\n  ]\n}";
                var lists = JsonConvert.DeserializeObject(json, typeof(Lists)) as Lists;
                var list = lists.Data.FirstOrDefault();
    
                Console.WriteLine("Name: " + list.Name);
                Console.WriteLine("List Id: " + list.ListId);
    
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    
        class Lists
        {
            public List<Info> Data { get; set; }
        }
    
        class Info
        {
            public string ListId { get; set; }
    
            public string Name { get; set; }
        }
    }
