    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    public class RootObject
    {
        public string url_short { get; set; }
        public string url_long { get; set; }
        public int type { get; set; }
    }
    
    public class Program
    {
        static public void Main()
        {
            string j = "[{\"url_short\":\"http:\\/\\/sample.com\\/8jyKHv\",\"url_long\":\"http:\\/\\/www.sample.com\\/\",\"type\":0}]";
    				
    		
    		List<RootObject> ro = JsonConvert.DeserializeObject<List<RootObject>>(j);
    		
    		Console.WriteLine(ro[0].url_short);
    				
        }
    
    }
