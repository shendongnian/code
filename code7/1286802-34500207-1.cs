    public class UserLoc
    {
        [Key]
        public int ul_id { get; set; }
    
        [ForeignKey("user")]
        public int fk_user_id { get; set; }
        public virtual User user { get; set; }
    
        [ForeignKey("location")]
        public int fk_location_id { get; set; }
        public virtual Locations location { get; set; }
    }
