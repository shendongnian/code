    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    namespace ConsoleApplication1
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var dict = new Dictionary<string, string>();
    
                dict.Add("FirstName", "Elmer");
                dict.Add("LastName", "Fudd");
                dict.Add("Password", @"\a\ansld\sb\b8d95nj");
    
                var json = JsonConvert.SerializeObject(dict);
    
                File.WriteAllText("values.json", json);
    
                var txt = File.ReadAllText("values.json");
                var newDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(txt);
    
            }
        }
    }
