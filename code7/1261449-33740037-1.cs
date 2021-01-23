        using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://steamcommunity.com/market/priceoverview/?currency=3&appid=440&market_hash_name=Genuine%20Purity%20Fist");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    
    
                StreamReader stream = new StreamReader(response.GetResponseStream());
    
    
                string final_response = stream.ReadToEnd();
                
                dynamic items = JObject.Parse(final_response);
                            
                bool success = items.success;
                string lowest = items.lowest_price;
                string volume = items.volume;
                string median = items.median_price;
    
                RootObject r = new RootObject(success,lowest,volume,median);
    
                Console.WriteLine("Success: "+r.success+", lPrice: "+r.lowest_price+", vol: "+r.volume+", mPrice: "+r.median_price);
    
                Console.WriteLine("Genuine Purity Fist");
                Console.WriteLine(final_response);
                Console.ReadKey();
            }
        }
    
        public class RootObject
        {
            public bool success { get; set; }
            public string lowest_price { get; set; }
            public string volume { get; set; }
            public string median_price { get; set; }
    
            public RootObject(bool success, string lowest_price, string volume, string median_price)
            {
                this.success = success;
                this.lowest_price = lowest_price;
                this.volume = volume;
                this.median_price = median_price;            
            }
        }
    }
