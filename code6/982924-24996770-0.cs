    public class Year
    {
        [Key]
        public int YearID { get; set; }
    
        public virtual ICollection<Week> Weeks { get; set; }
    }
    public class Week
    {
        [Key]
        public int WeekID { get; set; }
    
        public virtual Year year { get; set; }
        public virtual ICollection<Day> Days { get; set; }
    }
    public class Day
    {
        [Key]
        public int DayID { get; set; }
    
        public float Reading1 { get; set; }
        public float Reading2 { get; set; }
        public virtual Week Weeks { get; set; }
    }
