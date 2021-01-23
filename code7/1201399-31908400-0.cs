    public class SharedDocument
    {
        public string CreatedByID { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public string ModifiedByID { get; set; }
        public virtual ApplicationUser ModifiedBy { get; set; }
        // rest of your code
    }
