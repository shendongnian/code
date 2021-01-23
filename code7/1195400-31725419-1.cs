    public class Foo
    {
    	private readonly IBar _bar;
    
    	public Foo(IBar bar)
    	{
    		_bar = bar;
    	}
    
    	public void MyMethodToTest()
    	{
    		// Some stuff
    		_bar.SomethingToBeMocked();
    		//some more stuff
    	}
    }
