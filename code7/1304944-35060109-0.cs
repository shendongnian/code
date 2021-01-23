    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace DictionaryTest
    {
        class Program
        {
            public class DTO
            {
                public string Name { get; set; }
                public Dictionary<string, object> Data { get; set; }
            }
            static void Main(string[] args)
            {
                //var dictSerializer = new DictionaryInterfaceImplementerSerializer<Dictionary<string, object>>(DictionaryRepresentation.Document);
                //BsonClassMap.RegisterClassMap<DTO>(cm => cm.MapMember(dto => dto.Data).SetSerializer(dictSerializer));
                DTO instance = new DTO
                {
                    Name = "test",
                    Data = new Dictionary<string, object>
                    {
                        {"str", "thestring"},
                        {"byte", (byte)42},
                        {"bytearray", new byte[]{ 0x1, 0x2, 0x3}}
                    }
                };
                string serializedOne = JsonConvert.SerializeObject(instance);
                var col = new MongoClient("mongodb://localhost:27017").GetDatabase("test").GetCollection<DTO>("test");
                col.InsertOne(serializedOne);
                Console.WriteLine(serializedOne);
                Console.ReadKey();
            }
        }
    }
