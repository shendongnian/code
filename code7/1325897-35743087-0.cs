    public class RootObject
    {
          [JsonProperty(PropertyName = "type")] // It looks for 'type' name in json and set value in MyType property
          public string MyType{ get; set;}
    }
