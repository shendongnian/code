    public class GroupMembership
    {
        public int ID { get; set; }
        [Required]
        public int GroupID { get; set; }
        [Required]
        public string UserID { get; set; }
        [ForeignKey("GroupID")]
        public virtual Group Group { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
    }
