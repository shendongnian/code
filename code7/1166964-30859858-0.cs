    public class Member
    {
        [Key]
        [Column(Order = 0)]
        public string MemberId { get; set; }
        [Key]
        [Column(Order = 1)]
        public string GroupId { get; set; }
        public string MemberName { get; set; }     
        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
    }
