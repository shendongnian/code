    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    public class RootObject
    {
        public string chatName { get; set; }
        public List<string> users { get; set; }
        public bool someBooleanValue { get; set; }
        public dynamic someObjects { get; set; }
    }
    
    public class Program
    {
        static public void Main()
        {
            string j = "{\"chatName\": \"Test\",\"users\": [\"User1\",\"User2\"],\"someBooleanValue\": true,\"someObjects\": {\"object1\": \"someObjectValue1\",\"object2\": \"someObjectValue2\"}}";
    		
    		RootObject ro = JsonConvert.DeserializeObject<RootObject>(j);
    		
    		Console.WriteLine(ro.someObjects.object1);
        }    
    }
