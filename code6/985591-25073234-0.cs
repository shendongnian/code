    public class Data
    {
      [JsonProperty("messages")]
      public List<...> Messages { get; set; }
      [JsonProperty("m")]
      public List<...> m_list { 
        get{ return Messages; }
        set{ Messages = value; }
      }
      [JsonProperty("timestamp")]
      public int Timestamp { get; set; }
      ... 
      [JsonProperty("request")]
      public int RequestsLeft { get; set; }
      ...
    }
