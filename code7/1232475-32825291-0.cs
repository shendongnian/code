    void Main()
    {
    	var user = "{\"UserEvents\":[{\"OwnerSerno\":1214308,\"LastProfileDate\":20150801000000,\"IsRead\":true}]}";
    	UserEventLog convert = JsonConvert.DeserializeObject<UserEventLog>(user.ToString()) as UserEventLog;
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
        [JsonProperty("OwnerSerno")]
        public long OwnerSerno { get; set; }
          [JsonProperty("LastProfileDate")]
        public long LastProfileDate { get; set; }
          [JsonProperty("IsRead")]
        public bool IsRead { get; set; }
    }
