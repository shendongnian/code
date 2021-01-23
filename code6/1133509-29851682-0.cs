    public class Branch
    {
        [JsonProperty("@id")]
        public string Id { get; set; }
    }
    
    public class Opener
    {
        [JsonProperty("@Name")]
        public string Name { get; set; }
        [JsonProperty("@UserId")]
        public string UserId { get; set; }
        [XmlArray("Branches")]
        [XmlArrayItem("branch", typeof(Branch))]
        public List<Branch> Branches { get; set; }
    }
    
    
    public class RootObject
    {
        [XmlArray("Openers")]
        [XmlArrayItem("opener", typeof(Opener))]
        public List<Opener> Openers { get; set; }
    }
