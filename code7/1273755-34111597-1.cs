    public class Team
    {
        [Key]
        public int Id { get; set; }
        public bool AllowComments { get; set; }
        [ForeignKey("Member")]
        public int Captain { get; set; }
        [ForeignKey("CoMember")]
        public int? CoCaptain { get; set; }
        public virtual Member Member { get; set; }
        public virtual Member CoMember { get; set; }
    }
