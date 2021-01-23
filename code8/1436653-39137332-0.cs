    public class Program
    {
    	
    	public static void Main()
    	{
    		Foo[] Regions = new Foo[10];
    		
    		Regions[0] = new Foo();
    		
    		
    		if(Regions[0].Color.R == Regions[0].Color.G && Regions[0].Color.B != 0)
    		{
    			
    		}
    		
    		
    	}
    }
    
    public struct Foo
    {
    	public Color Color { set; get; }
    }
