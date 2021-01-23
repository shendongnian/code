    public class PlayerAccount
    {
        [Key]
        public int PlayerID { get; set; }
        public string Category { get; set; }
        public bool LeagueEmails { get; set; }
        public bool GameReminders { get; set; }
        [ForeignKey("PlayerID")]
        public virtual Player Player { get; set; }
    }
