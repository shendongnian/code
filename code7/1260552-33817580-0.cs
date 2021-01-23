        [Display(Name = "Home Team")]
        public virtual Guid? HomeTeamId { get; set; }
        [ForeignKey("HomeTeamId")]
        [InverseProperty("HomeGames")] // Added this - 
        public virtual Team HomeTeam { get; set; }
        [Display(Name = "Away Team")]
        public virtual Guid? AwayTeamId { get; set; }
        [ForeignKey("AwayTeamId")]
        [InverseProperty("AwayGames")] // Added this - 
        public virtual Team AwayTeam { get; set; }
