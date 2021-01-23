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
                string configJson = JsonConvert.SerializeObject(configuration);
                File.WriteAllText(configPath, configJson);
                //read  the  content after you read your file in string 
  
                 var   configurationDeserialized = JsonConvert.DeserializeObject<Configuration>(configJson); 
    
    
    
            }
        }
    }
    
    public class Configuration
    {
         [JsonIgnore]
        public List<Tuple<int, int, int>> MyThreeTuple { get; set; }
    
        public Configuration()
        {
            MyThreeTuple = new List<Tuple<int, int, int>>();
            MyThreeTuple.Add(new Tuple<int, int, int>(-100, 20, 501));
            MyThreeTuple.Add(new Tuple<int, int, int>(100, 20, 864));
            MyThreeTuple.Add(new Tuple<int, int, int>(500, 20, 1286));
        }
    }
