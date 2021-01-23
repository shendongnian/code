    public class trans
    {
        [Key]
        public int tID { get; set; }
        public virtual Location Location { get; set; }
    }
    public class Location
    {
        public int locID { get; set; }
    } 
