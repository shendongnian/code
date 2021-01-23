    public class Alarm
    {
        public int id { get; set; }
        public int AssignedTo { get; set; }
        [ForeignKey("AssignedTo")] 
        public virtual User User { get; set; }
        public bool Resolved { get; set; }
    }
