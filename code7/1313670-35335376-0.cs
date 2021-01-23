    public class Employee
    {
        [JsonProperty("_id")]
        public ObjectId Id { get; private set; }
        [JsonProperty("empname")]
        public string Name { get; set; }
        [JsonProperty("empcode")]
        public string Code { get; set; }
        [JsonProperty("level")]
        public Level Level { get; set; }
        [JsonProperty("Address")]
        public List<Address> Addresses { get; set; }
    }
    
    public class Level
    {
        [JsonProperty("levelID")]
        public string Id { get; set; }
        [JsonProperty("levelDescription")]
        public string Description { get; set; }
        [JsonProperty("levelCode")]
        public string Code { get; set; }
    }
    // This structure is unfortunate, but imposed by the JSON
    public class Address
    {
        public StreetAddress Home { get; set; }
        public StreetAddress Office { get; set; }
        public List<Home> Home { get; set; }
        public List<office> Office { get; set; }
    }
    public class Home
    {
        public string streetname { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }
    public class office
    {
        public string streetname { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }
