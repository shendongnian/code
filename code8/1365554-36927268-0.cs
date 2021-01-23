    using System;
    
    public class A
    {
        public event Action Event;
    		
    	// You could just use System.Action, but I want the example to be clear
    	public delegate void HandlerDelegateType();
    	
    	public HandlerDelegateType PublicDelegate;
    	
    	
    	public void Fire()
    	{
    		if(PublicDelegate != null)
    		{
    			PublicDelegate();
    		}
    	}
    }
    
    public static class MainClass
    {
    	public static int Main(string[] args)
    	{
    		var a = new A();
    		
    		if(a.PublicDelegate == null)
    		{
    			Console.WriteLine("a.PublicDelegate is null");
    		}
    		
    		a.PublicDelegate += () => { Console.WriteLine("First handler fired!"); };
    		a.PublicDelegate += () => { Console.WriteLine("Second handler fired!"); };
    											  
    		
    		a.Fire();
    		
    		if(a.PublicDelegate != null)
    		{
    			Console.WriteLine("a.PublicDelegate is not null");
    		}
    		
    		
    		return 0;
    	}
    }
