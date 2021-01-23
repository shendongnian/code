    public class School
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolID { get; set; }
    
        public string DayEvent { get; set; }
        public string DayNote { get; set; }
        // ...
    }
