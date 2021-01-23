    public interface IGetCost
    {
    	int GetCost();
    }
    
    public class Pipe : IGetCost
    {
    	public int GetCost(){}
    }
    
    public class BigFatPipe : IGetCost
    {
        //aggregation
    	private readonly Pipe _pipe;
    	public BigFatPipe(Pipe pipe)
    	{
    		_pipe = pipe;
    	}
    	public int GetCost() { }
    }
    
    public class CheapestPossiblePipe : IGetCost
    {
    	private readonly Pipe _pipe;
    
    	public CheapestPossiblePipe(Pipe pipe)
    	{
    		_pipe = pipe;
    	}
    	public int GetCost() { }
    }
    
    public static void PrintPrice(IGetCost obj)
    {
    	int cost = obj.GetCost();
    	Console.WriteLine(cost);
    }
    
    static void Main(string[] args)
    {
    	IGetCost p;
    
    	p = new Pipe();
    	PrintPrice(p);
    
    	p = new BigFatPipe();
    	PrintPrice(p);
    
    	p = new CheapestPossiblePipe();
    	PrintPrice(p);
    }
