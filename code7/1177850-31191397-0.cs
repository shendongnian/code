    void Example()
    {
    	Random random = new Random();
    	List<Tally> tallies = new List<Tally>
    	{
    		new Tally("SubTally", random.Next(0,100)),
    		new Tally("DomTally", random.Next(0,100)),
    		new Tally("SimTally", random.Next(0,100)),
    		new Tally("GroTally", random.Next(0,100)),
    		new Tally("DefTally", random.Next(0,100)),
    		new Tally("AccTally", random.Next(0,100)),
    		new Tally("ConTally", random.Next(0,100))
    	};
    	
    	int sum = tallies.Sum(tally => tally.Score);
    	var topThreeTallies = tallies.OrderByDescending(tally => tally.Score)
    		   .Take(3)
    		   .Select(tally => new 
    		   {
    		        tally.Name,
    				tally.Score,
    				Percentage =  ((decimal) tally.Score / sum) * 100M
    			});
   	
    }
    
    public class Tally
    {
    	public Tally(string name)
    	{
    		this.Name = name;
    	}
    
    	public Tally(string name, int score)
    	{
    		this.Name = name;
    		this.Score = score;
    	}
    
    	public string Name { get; set; }
    	public int Score { get; set; }
    }
