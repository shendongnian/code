    void Main()
    {
    	var user = "{\"UserEvents\":[{\"id\":1214308,\"Date\":20150801000000,\"IsRead\":true}]}";
    	UserEventLog convert = JsonConvert.DeserializeObject<UserEventLog>(user.ToString());
    	convert.UserEvents.Count().Dump();
    }
    
    public class UserEventLog {
        [JsonProperty("UserEvents")]
        public List<UserEvent> UserEvents { get; set; }
        public UserEventLog() {
            UserEvents = new List<UserEvent>();
        }
    }
    public class UserEvent {
        [JsonProperty("id")]
        public long id{ get; set; }
          [JsonProperty("Date")]
        public long Date{ get; set; }
          [JsonProperty("IsRead")]
        public bool IsRead { get; set; }
    }
