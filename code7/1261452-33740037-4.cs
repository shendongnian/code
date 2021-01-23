     using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
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
                
    
                var final_response = stream.ReadToEnd();
    
                // Converts the unicode to string correctValue.
                
                
                string correctValue = "Euro";
                StringBuilder sb = new StringBuilder(final_response);
                if (sb.ToString().Contains("\\u20ac"))
                {                
                    sb.Replace("\\u20ac", correctValue);
                }            
                
                dynamic items = JObject.Parse(sb.ToString());
    
                bool success = items.success;
                string lowest = items.lowest_price;
                string volume = items.volume;
                string median = items.median_price;            
    
                // Create a test object of RootObject class and display it's values in cw.
                RootObject r = new RootObject(success, lowest, volume, median);
                Console.WriteLine("TEST OBJECT VALUES: Success: " + r.success + ", lPrice: " + r.lowest_price + ", vol: " + r.volume + ", mPrice: " + r.median_price + "\n");
    
                // Calculation example
                double num1 = Convert.ToDouble(r.FixComma(r.lowest_price,correctValue));
                double num2 = Convert.ToDouble(r.FixComma(r.median_price, correctValue));
                double result = num1 + num2;
                Console.WriteLine("Result: " + result+"\n");
    
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
    
            public string FixComma(string value,string currency)
            {
                string correctValue = ".";
                string correctValue2 = "";
                StringBuilder sb = new StringBuilder(value);
                if (sb.ToString().Contains(","))
                {
                    sb.Replace(",", correctValue);
                }
                if (sb.ToString().Contains(currency))
                {
                    sb.Replace(currency, correctValue2);
                }
                return sb.ToString();
            }
        }
    }
