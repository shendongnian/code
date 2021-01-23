    [JsonObject]
    public class Employee 
    {
        [JsonProperty("name")]
        string name;
        Position position;
    }
    [JsonObject]
    public class Position 
    {
        [JsonProperty("positionName")]
        string positionName;
        [JsonProperty("salary")]
        int salary;
    }
