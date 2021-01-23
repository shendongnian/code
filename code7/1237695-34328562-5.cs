    public class Room
    {
        public int RoomID { get; set; }
        public string Name { get; set; }
        public int? AvailableSeats { get; set; }
        public int? TotalSeats { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Usage> Usages { get; set; }
    }
