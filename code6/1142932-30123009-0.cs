    class Team
    {
    	public List<Player> Players { get; set; }
    	public Player Captain { get { return Players.Find(p => p.IsCaptain); } }
    }
    class Player
    {
    	public string ID { get; set; }
    	public bool IsCaptain { get; set; }
    }
