    public class Children
        {
            [JsonProperty("name")]
            public string Name { get; set; }
        }
        public class YourClass
        {
            [JsonProperty("@@hello")]
            public string Hello { get; set; }
            [JsonProperty("#world")]
            public string World { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("firstname")]
            public string FirstName { get; set; }
            [JsonProperty("lastname")]
            public string LastName { get; set; }
            [JsonProperty("children")]
            public Children[] Children { get; set; }
        }
            var json1 = "{ '@@hello': 'address','#world': 'address1','name': 'address'}";
            var json2 = "{ '@@hello': 'address','#world': 'address1','name': 'address', 'firstname': 'foo', 'lastname':'bar'}";
            var json3 = "{ '@@hello': 'address','#world': 'address1','name': 'address','children': [{'name':'foo'},{'name':'bar'}]}";
            var model1 = JsonConvert.DeserializeObject<YourClass>(json1);
            var model2 = JsonConvert.DeserializeObject<YourClass>(json2);
            var model3 = JsonConvert.DeserializeObject<YourClass>(json3);
