    class Reservation
    {
        public string Who { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
    
    class Room
    {
        public int Number { get; set; }
        public LinkedList<Reservation> Reservations { get; set; }
    }
    
    LinkedList<Room> rooms = new LinkedList<Room>();
