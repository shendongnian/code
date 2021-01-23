    [JsonObject]
    public class Employee 
    {
        [JsonProperty("name")]
        string name;
        [JsonProperty("positionName")]
        string positionName;
        [JsonProperty("salary")]
        int salary;
    }
