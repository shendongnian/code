    public class Invitation
    {
        [Key]
        public int Key { get; set; }
        [ForeignKey("Host")]
        public string HostId { get; set; }
        public virtual ApplicationUser Host { get; set; }
        [ForeignKey("Invitee")]
        public string InviteeId { get; set; }
        public virtual ApplicationUser Invitee { get; set; }
    }
