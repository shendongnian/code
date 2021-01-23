    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string JSONInput = @"{""Items"":[{""Id"":""20"",""CaptureCategoryTypeId"":5021,""Name"":""24270"",""Description"":""FSH CARRIBEAN CAPTAIN"",""IsEnabled"":true}],""TotalResults"":0}";
                BlahObject deserializedProduct = JsonConvert.DeserializeObject<BlahObject>(JSONInput);
                Console.ReadKey();
            }
        }
    
        public class DataDetails
        {
            public string Id { get; set; }
            public int CaptureCategoryTypeId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public bool IsEnabled { get; set; }
        }
    
        public class BlahObject
        {
            public List<DataDetails> Items { get; set; }
            public int TotalResults { get; set; }
        }
    }
