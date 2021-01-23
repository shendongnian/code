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
        [JsonProperty("Home")]
        public StreetAddress Home { get; set; }
        [JsonProperty("Office")]
        public StreetAddress Office { get; set; }
    }
    public class StreetAddress
    {
        [JsonProperty("streetname")]
        public string StreetName { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
    }
