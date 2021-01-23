    public class Team
    {
        public Team(string name, int seed){
            Name = name;
            Seed = seed;
        }
        public string Name {get; set;}
    	public int Seed {get; set;}
	
    	//simple method to compare two teams' seed values and return the better (1 > 2) team
        public static Team GetBetterSeed(Team t1, Team t2){
    		return t1.Seed < t2.Seed ? t1 : t2;
    	}
    }
    public class Matchup
    {
    	public Matchup(Team t1, Team t2){
    		Team1 = t1;
    		Team2 = t2;
    	}
	
	    public Team Team1 {get; set;}
    	public Team Team2 {get; set;}
	
        //"Team 1's Name vs. Team 2's Name"
	    public override string ToString(){
    		return Team1.Name + " vs. " + Team2.Name;
    	}
	
        //using the GetBetterSeed() method above we can get which team out of a matchup is favored
	    public Team GetFavored(){
    		return Team.GetBetterSeed(Team1, Team2);
    	}
    }
