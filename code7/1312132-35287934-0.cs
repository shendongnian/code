    public class playerWrapper
    {
        public player player{ get; set; }
    }
    public class player
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    public class ReservationModelForJson
    {
        ...
        public IEnumerable<playerWrapper> players { get; set; }
    }
    public class JsonBinder
    {
        public ReservationModelForJson reservation { get; set; }
    }
