    namespace Q38072488.Json
    {
      using Newtonsoft.Json;
      public class CDataText
      {
          [JsonProperty("#cdata-section")]
          public string CDATA_Section { get; set; }
      }
      public class RootObject
      {
          [JsonProperty("text")]
          public CDataText Text { get; set; }
      }
    } 
