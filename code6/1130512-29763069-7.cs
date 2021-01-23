    public class SomeClass
    {
    	private static readonly Apple a, c;
    	private static Orange _b;
        private readonly Orange b;
    	
    	static SomeClass()
    	{
        	a = new Apple();		
    		_b = new Orange(a.getDna());
        	c = new Apple(_b.getDna());
    	}
    
    	public SomeClass()
    	{
    		b = _b;
            _b = null;
    	}
        //
        // the rest is just class definitions
        //     	
    	public class Apple
    	{
    		public Apple(object o = null) {}
    		public object getDna() { return new object(); }
    	}
    	
    	public class Orange
    	{
    		public Orange(object o = null) { }
    		public object getDna() { return new object(); }
    	}
    }
