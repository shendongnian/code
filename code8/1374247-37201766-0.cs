    public class WordChallenge
    {
        [Required]
        public Guid IssuingPlayerID
    
        [Required]
        public Guid ChallengedPlayerID
    
        [ForeignKey("IssuingPlayerId")]
        public virtual Player IssuingPlayer { get; set; }
    
        [ForeignKey("ChallengedPlayerID")]
        public virtual Player ChallengedPlayer { get; set; }
    }
