    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace NewtonSoftSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                string json =
    @"
    [
      {
        ""msys"": {
          ""message_event"": {
            ""type"": ""bounce"",
            ""bounce_class"": ""1"",
            ""campaign_id"": ""Example Campaign Name"",
            ""customer_id"": ""1"",
            ""delv_method"": ""esmtp"",
            ""device_token"": ""45c19189783f867973f6e6a5cca60061ffe4fa77c547150563a1192fa9847f8a"",
            ""error_code"": ""554"",
            ""ip_address"": ""127.0.0.1"",
            ""message_id"": ""0e0d94b7-9085-4e3c-ab30-e3f2cd9c273e"",
            ""msg_from"": ""sender@example.com"",
            ""msg_size"": ""1337"",
            ""num_retries"": ""2"",
            ""rcpt_meta"": {
              ""customKey"": ""customValue""
            },
            ""rcpt_tags"": [
              ""male"",
              ""US""
            ],
            ""rcpt_to"": ""recipient@example.com"",
            ""rcpt_type"": ""cc"",
            ""raw_reason"": ""MAIL REFUSED - IP (17.99.99.99) is in black list"",
            ""reason"": ""MAIL REFUSED - IP (a.b.c.d) is in black list"",
            ""routing_domain"": ""example.com"",
            ""subject"": ""Summer deals are here!"",
            ""template_id"": ""templ-1234"",
            ""template_version"": ""1"",
            ""timestamp"": 1427736822,
            ""transmission_id"": ""65832150921904138""
          }
        }
      }
    ]
    ";
    
                var des = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Class1>>(json);
    
                Console.WriteLine("Done");
    
                Console.ReadLine();
    
            }
        }
    
        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }
    
        public class Class1
        {
            public Msys msys { get; set; }
        }
    
        public class Msys
        {
            public Message_Event message_event { get; set; }
        }
    
        public class Message_Event
        {
            public string type { get; set; }
            public string bounce_class { get; set; }
            public string campaign_id { get; set; }
            public string customer_id { get; set; }
            public string delv_method { get; set; }
            public string device_token { get; set; }
            public string error_code { get; set; }
            public string ip_address { get; set; }
            public string message_id { get; set; }
            public string msg_from { get; set; }
            public string msg_size { get; set; }
            public string num_retries { get; set; }
            public Rcpt_Meta rcpt_meta { get; set; }
            public string[] rcpt_tags { get; set; }
            public string rcpt_to { get; set; }
            public string rcpt_type { get; set; }
            public string raw_reason { get; set; }
            public string reason { get; set; }
            public string routing_domain { get; set; }
            public string subject { get; set; }
            public string template_id { get; set; }
            public string template_version { get; set; }
            public int timestamp { get; set; }
            public string transmission_id { get; set; }
        }
    
        public class Rcpt_Meta
        {
            public string customKey { get; set; }
        }
    }
