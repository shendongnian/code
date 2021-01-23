    public class Player
    {
    	public Player()
    	{
    		Name = new PlayerName();
    		ByeWeeks = new ByeWeeks();
    		Headshot = new Headshot();
    		EligiblePositions = new List<EligiblePosition>();
    	}
    
    	[JsonProperty(PropertyName = "player_key")]
    	public string PlayerKey { get; set; }
    
    	[JsonProperty(PropertyName = "player_id")]
    	public string PlayerId { get; set; }
    
    	[JsonProperty(PropertyName = "name")]
    	public PlayerName Name { get; set; }
    
    	[JsonProperty(PropertyName = "editorial_player_key")]
    	public string EditorialPlayerKey { get; set; }
    
    	[JsonProperty(PropertyName = "editorial_team_key")]
    	public string EditorialTeamKey { get; set; }
    
    	[JsonProperty(PropertyName = "editorial_team_full_name")]
    	public string EditorialTeamFullName { get; set; }
    
    	[JsonProperty(PropertyName = "editorial_team_abbr")]
    	public string EditorialTeamAbbr { get; set; }
    
    	[JsonProperty(PropertyName = "bye_weeks")]
    	public ByeWeeks ByeWeeks { get; set; }
    
    	[JsonProperty(PropertyName = "uniform_number")]
    	public string UniformNumber { get; set; }
    
    	[JsonProperty(PropertyName = "display_position")]
    	public string DisplayPosition { get; set; }
    
    	[JsonProperty(PropertyName = "headshot")]
    	public Headshot Headshot { get; set; }
    
    	[JsonProperty(PropertyName = "image_url")]
    	public string ImageUrl { get; set; }
    
    	[JsonProperty(PropertyName = "is_undroppable")]
    	public string IsUndroppable { get; set; }
    
    	[JsonProperty(PropertyName = "position_type")]
    	public string PositionType { get; set; }
    
    	[JsonProperty(PropertyName = "eligible_positions")]
    	public List<EligiblePosition> EligiblePositions { get; set; }
    }
