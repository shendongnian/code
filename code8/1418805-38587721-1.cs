    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    public class Message
    {
        public string body { get; set; }
        public int id { get; set; }
        public int id_thread { get; set; }
    }
    
    public class RootObject
    {
        public string status { get; set; }
        public Message message { get; set; }
        public int id_thread { get; set; }
    }
    
    public class Program
    {
        static public void Main()
        {
            string j = "{\"status\":\"response_ok\",\"message\":{\"body\":\"Hi test,\r\n\r\ntesting it, lorem ipsum lorem ipsumlorem ipsumlorem ipsumlorem ipsum.\r\n\r\nSignature\",\"id\":1015,\"id_thread\":741},\"id_thread\":741} ";
    		
    		RootObject ro = JsonConvert.DeserializeObject<RootObject>(j);
    		
    		Console.WriteLine(ro.message.body);
        }
    
    }
