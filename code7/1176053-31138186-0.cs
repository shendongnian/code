    [ForeignKey("Game")]
    public int GameId { get; set; }
    public virtual Game Game { get; set; }
    [ForeignKey("NextGame")]
    public int NextGameId { get; set; }        
    public virtual Game NextGame { get; set; }
