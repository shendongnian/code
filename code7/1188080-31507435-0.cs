    public class User
    {
        public int id { get; set; }
        public string UserName { get; set; }
        //flags user to be deleted when room is no longer available
        public bool temporaryUser { get; set; }
        public bool? isHost { get; set; }
        [JsonIgnore]
        public int? RoomId { get; set; }
        public virtual Room Room { get; set; }
        [JsonIgnore]
        public bool permanent { get; set; }
    }
    public class Room
    {
        public int id { get; set; }
        public string RoomName { get; set; }
    }
