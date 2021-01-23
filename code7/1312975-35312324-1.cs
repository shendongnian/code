    using System;
    using Newtonsoft.Json.Linq;
    
    class Test
    {
        static void Main()
        {
            string json = "{ 'name': 'SUSHIL' }";
            JObject obj = JObject.Parse(json);
            obj["FirstName"] = obj["name"];
            obj.Remove("name");
            Console.WriteLine(obj);
        }
    }
