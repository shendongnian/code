    [JsonObject]
    public class MyClass
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "devName")]
        public string DevName { get; set; }
        [JsonProperty(PropertyName = "ReturnedData")]
        public List<ReturnedData> ReturnedData { get; set; }
    }
    [JsonObject]
    public class ReturnedData
    {
        [JsonProperty(PropertyName = "level_heading")]
        public string level_heading { get; set; }
        [JsonProperty(PropertyName = "DeliverBestMedicalValue")]
        public string DeliverBestMedicalValue { get; set; }
        [JsonProperty(PropertyName = "level_question")]
        public string LevelQuestion { get; set; }
    }
    // propertyname attributes can be ignored if property names 
    // match the json data property names 1:1
