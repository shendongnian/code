    public class Team
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string TeamName { get; set; }
        public string Coach { get; set; }
        public string Conference { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
