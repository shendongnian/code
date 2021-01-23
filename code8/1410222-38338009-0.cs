    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string JSONInput = @"{""SN0124"": {
                                        ""category1"": 0,
                                        ""output"": {
                                            ""ABC"": [], 
                                            ""DEF"": 0, 
                                            ""GHI"": ""ABDEF""
                                        },
                                        ""category2"": 0, 
                                        ""category3"": 0
                                    },
                                    ""SN0123"": {
                                        ""category1"": 0, 
                                        ""output"": {
                                            ""ABC"": [""N1"", ""N2""], 
                                            ""DEF"": 0, 
                                            ""GHI"": ""ABDEF""
                                        },
                                        ""category2"": 0, 
                                        ""category3"": 0
                                    }}";
                Dictionary<string, Pets> deserializedProduct = JsonConvert.DeserializeObject<Dictionary<string, Pets>>(JSONInput);
                Console.ReadKey();
            }
        }
    
        public class Output
        {
            public string[] ABC { get; set; }
            public int DEF { get; set; }
            public string GHI { get; set; }
        }
    
        public class Pets
        {
    
            public int category1 { get; set; }
    
            public Output output { get; set; }
    
            public int category2 { get; set; }
            public int category3 { get; set; }
    
        }
    }
