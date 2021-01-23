    public class FooData
    {
    	public int Status { get; set; }
    	public bool Active { get; set; }
    
    	public static Expression<Func<FooData, bool>> IsSpecialThing = (foo) => foo.Active && (foo.Status == 3 || foo.Status == 4);	
    }
