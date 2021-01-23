    public class Person
    {
        public string FirstName = "John";
        public string LastName = "Smith";
        [JsonIgnore]
        public string Json = "{ \"Age\": 30 }";
        public JObject JsonP { get { return JsonConvert.DeserializeObject<JObject>(Json); } }
    }
