    public class WordChallenge
    {
        [Required]
        public Guid IssuingPlayerID { get; set; }
    
        [Required]
        public Guid ChallengedPlayerID { get; set; }
    
        [ForeignKey("IssuingPlayerId")]
        public virtual Player IssuingPlayer { get; set; }
    
        [ForeignKey("ChallengedPlayerID")]
        public virtual Player ChallengedPlayer { get; set; }
    }
