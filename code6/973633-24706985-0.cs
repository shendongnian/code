    public class Reservation
    {
        public int ID { get; set; }
        public int SpaceNumber { get; set; }
        public string UserName{ get; set; }
    
        [ForeignKey("Game")]
        public int GameID{ get; set;}
        public virtual Game Game { get; set; }
    
        public Reservation() { }
    }
