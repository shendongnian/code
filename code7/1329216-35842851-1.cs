    public static class Test
    {
    	static Test()
    	{
    		Add = Curry<int,int,int>((x, y) => x+y);
    		Multiply = Curry<int,int,int>((x, y) => x*y);
    	}
    
    	public static Func<int, Func<int, int>> Add { get; }
    	public static Func<int, Func<int, int>> Multiply { get; }
    		
    	public static Func<T1, Func<T2, T3>> Curry<T1, T2, T3>(Func<T1, T2, T3> f) {
    	  return x => y => f(x, y);
    	}
    }
