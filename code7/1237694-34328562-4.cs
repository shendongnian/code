    public class Team
    {
        public int TeamID { get; set; }
        public int? RoomID { get; set; }
        public string Warning { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Contest> Contests { get; set; }
    }
