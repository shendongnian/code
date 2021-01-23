    public class WebService
    {
      public string swagger;
      [JsonExtensionData]
      public Dictionary<string, object> AllOthers;
    }
    var ws = Newtonsoft.Json.JsonConvert.DeserializeObject<WebService>(json);
