    using System.Text.Json.Serialization;
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MyEnum
    {
        A, B
    }
