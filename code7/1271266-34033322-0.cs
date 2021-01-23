    public class A {
    	public List<B> Objects { get; set; }
    }
    
    public class B {
    	public B(int i) { }
    	//blah
    }
    
    public static void Main(string[] args)
    {
        //Establish a simple object Heiarchy
        //Root: A
        /*
    
        A
        |-B1
        |-B2
        |-B3
    
        */
    	var alpha = new A()
    	{
    		Objects = new List<B>()
    		{
    			new B(1),
    			new B(2),
    			new B(3)
    		}
    	}
    
    	//MagicMethod<T>(object objectToTrace) is the mythical method that we're looking for
    
    	//What you're looking for is something like this:
    	MagicMethod(alpha.Objects[1]); //Should output "alpha.Objects[1]"
    
    	//But what if we make another reference to the same object?
    
    	var beta = alpha.Objects[1];
    
    	//Now what would MagicMethod() produce?
    	MagicMethod(beta); //would have to produce "beta"
        //How is it possible that when We've called MagicMethod() with 
        //fundamentally the same argument, we get two different outputs?
    }
