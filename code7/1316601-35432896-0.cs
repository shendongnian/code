    public class Player
    {
    	public string Name { get; set; }
    	public int Score { get; set; }
    }
    
    var topList = new List<Player>();
    topList = topList.OrderBy(x => x.Score);
