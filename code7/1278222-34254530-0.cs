    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string CaptainId { get; set; }
        public string CoCaptainId { get; set; }
        public string ContactDetails { get; set; }
    }
    public class TeamMember
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string GameDisplayName { get; set; }
        public DateTime Joined { get; set; }
        public Guid TeamId { get; set; }
        public virtual Team Team { set; get; }
    }
