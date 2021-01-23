    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    
    namespace ConsoleApplication25
    {
        class Program
        {
            static void Main(string[] args)
            {
                Configuration configuration = new Configuration();
                string str = JsonConvert.SerializeObject(configuration);
                 var   configurationDeserialized = JsonConvert.DeserializeObject<Configuration>(str); 
    
    
    
            }
        }
    }
    
    public class Configuration
    {
        public List<Tuple<int, int, int>> MyThreeTuple { get; set; }
    
        public Configuration()
        {
            MyThreeTuple = new List<Tuple<int, int, int>>();
            MyThreeTuple.Add(new Tuple<int, int, int>(-100, 20, 501));
            MyThreeTuple.Add(new Tuple<int, int, int>(100, 20, 864));
            MyThreeTuple.Add(new Tuple<int, int, int>(500, 20, 1286));
        }
    }
