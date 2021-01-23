    public class Gear
    {
    	public int Chainring { get; set; }
    	public int Cog { get; set; }
    	public int Wheel { get; set; }
    }
    // ...
	var gear = new Gear
	{
		// could be in any order, 
		Cog = 11,
		Chainring = 52,
	}
