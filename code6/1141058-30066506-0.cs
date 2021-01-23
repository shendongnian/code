    public class A
    {
       public B _b;
    
       public A()
       {
           _b = new B(this);
       }
    }
        
    public class B
    {
    	public A _a;
    	
    	public B(A a)
    	{
    		_a = a;
    	}
    }
