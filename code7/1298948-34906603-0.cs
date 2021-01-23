    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    namespace ConsoleApplication
    {
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            JArray array = new JArray();
            array.Add("Manual text");
            array.Add(new DateTime(2000, 5, 23));
            JObject o = new JObject();
            o["MyArray"] = array;
            string json = o.ToString();
            Console.WriteLine(json);
            
            Console.Read();
        }
    }
    }
