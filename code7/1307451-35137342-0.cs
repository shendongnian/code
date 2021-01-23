    // I would change the class name to ElementDO in order to be consist with .NET Naming Conventions
    public class elementDO
    {
    	public int AtomicNumber { get; set; }
    	public string Symbol { get; set; }
    	public string Name { get; set; }
    	public decimal AtomicWeight { get; set; }
    	
    	public override string ToString()
    	{
    		return string.Format("{0}:{1}:{2}:{3}", AtomicNumber, Symbol, AtomicWeight, Name);
    	}
    }
