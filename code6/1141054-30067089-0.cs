    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var json = File.ReadAllText("C:\\Users\\Tynar\\Documents\\json.txt");
                
                RootObject itemPrices = JsonConvert.DeserializeObject<RootObject>(json);
    
                int buyPrice = itemPrices.results[0].min_sale_unit_price;
                int sellPrice = itemPrices.results[0].max_offer_unit_price;
    
                Console.WriteLine(buyPrice);
                Console.WriteLine(sellPrice);
                Console.ReadLine();
            }
        }
    
        public class Result
        {
            public int data_id { get; set; }
            public string name { get; set; }
            public int rarity { get; set; }
            public int restriction_level { get; set; }
            public string img { get; set; }
            public int type_id { get; set; }
            public int sub_type_id { get; set; }
            public string price_last_changed { get; set; }
            public int max_offer_unit_price { get; set; }
            public int min_sale_unit_price { get; set; }
            public int offer_availability { get; set; }
            public int sale_availability { get; set; }
            public int sale_price_change_last_hour { get; set; }
            public int offer_price_change_last_hour { get; set; }
        }
    
        public class RootObject
        {
            public int count { get; set; }
            public int page { get; set; }
            public int last_page { get; set; }
            public int total { get; set; }
            public List<Result> results { get; set; }
        }
    }
