    public class Person
    {
        // ignore property
        [JsonIgnore]
        public string Title { get; set; }
    // rename property
    [JsonProperty("firstName")]
    public string FirstName { get; set; }
    }
