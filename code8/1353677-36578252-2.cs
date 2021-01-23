    public class UsrDetails
    {
        [Key]
        public int UsrID{ get; set; }
        [ForeignKey("UsrID")]
        public virtual Usr Usr { get; set; }
    }
