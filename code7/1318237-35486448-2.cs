    public class Self
    {
        public string DeviceID { get; set; }
        public string TimeStamp { get; set; }
    }
    public class Location
    {
        public string RoomID { get; set; }
        public string Room { get; set; }
    }
    public class Friend
    {
        public string IdUser { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
    }
    public class RootObject
    {
        public Self Self { get; set; }
        public List<Friend> Friends { get; set; }
    }
