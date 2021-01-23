    public class ResponseData
    {
        [JsonProperty("result")]
        public LiveLeagues Result{ get; set; }
    }
    public class LiveLeagues
    {
        [JsonProperty("games")]
        public List<ViewLiveLeaguePlayers> Games{ get; set; }
    }
