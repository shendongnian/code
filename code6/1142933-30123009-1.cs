    class Team
    {
    	public List<Player> Players { get; set; }
    	public string CaptainID { get; set; }
    
    	[NonSerialized]
    	[System.Xml.Serialization.XmlIgnore]
    	public Player Captain { get { return Players.Find(p => p.ID == CaptainID); } }
    }
