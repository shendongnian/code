    public class Lineup
    {
    	public List<Dictionary<string,Player>> lineups;
    }
    
    public class Player
    {
    	public string id {get; set; }
    	public string game_id { get; set;}
    	public string player_id {get;set;}
    	public string jersey_number {get;set;}
    }
