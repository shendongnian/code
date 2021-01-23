    public class UsrDetails
    {
        [Key]
        public int UserID { get; set; }
        [ForeignKey("UsrID")]
        public virtual Usr Usr { get; set; }
    }
