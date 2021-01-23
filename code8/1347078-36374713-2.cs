    public class Schedule
    {
        public Schedule()
        {
            Seances = new List<Seance>();
        }
        [Key]
        public int IdSchedule { get; set; }
        public string Cinema { get; set; }
        public string Movie { get; set; }
        public DateTime DateSchedule { get; set; }
        public virtual ICollection<Seance> Seances { get; set; }
    }
    
    public class Seance
    {
        [Key]
        public int IdSeance { get; set; }
        public DateTime DateSeance { get; set; }
        public int IdSchedule { get; set; }
        [ForeignKey("IdSchedule")]
        public virtual Schedule Schedule{ get; set; }
    }
