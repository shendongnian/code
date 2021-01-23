    public class RootObject
    {
        [JsonProperty("persons")]
        public List<Person> People { get; set; }
        // This is visible to Json.Net and references the real list
        [JsonProperty("person")]
        private List<Person> Person
        {
            get { return People; }
            set { People = value; }
        }
    }
    public class Person
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("hobbies")]
        public List<Hobby> Hobbies { get; set; }
    }
    public class Hobby
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("hours")]
        public int Hours { get; set; }
    }
