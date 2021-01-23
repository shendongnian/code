    using System;
    using Newtonsoft.Json;
    
    namespace MyNamepace
    {
        public class MyCustomObject
        {
            public MyCustomObject()
            {
            }
    
            [JsonProperty(PropertyName = "my_int_one")]
            public int MyIntOne { get; set; }
    
            [JsonProperty(PropertyName = "my_bool_one")]
            public bool MyBoolOne { get; set; }
    
        }
    }
