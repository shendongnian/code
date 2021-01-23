    public class Player2
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    
    public class Player
    {
        public Player2 player { get; set; }
    }
    
    public class Reservation
    {
        public string ticketId { get; set; }
        public int clubId { get; set; }
        public int courtNumber { get; set; }
        public string crud_name { get; set; }
        public string reservationtype_name { get; set; }
        public List<Player> players { get; set; }
    }
    
    public class RootObject
    {
        public Reservation reservation { get; set; }
    }
