    public class Program
    {
    	public void Main(string[] args)
    	{
    		MyThing a = new MyThing();
    		MyThing b = new MyThing();
    		a.SetValues(b);//calls more specific
    		a.SetValues((ISomething)b);//calls just the thing
    	}	
    }
    
    
    public class MyThing : ISomethingMoreSpecific
    {
    	public void SetValues(ISomethingMoreSpecific specificThing)
    	{
    		Console.WriteLine ("more specific");
    	}
    	
    	public void SetValues(ISomething thing)
    	{
    		Console.WriteLine ("just the thing");
    	}
    }
    
    public interface ISomethingMoreSpecific : ISomething
    { 
        //...existing + my props, 
        new void SetValues(ISomething thing);
    }
    
    public interface ISomething
    {
        //...many auto-props, 
        void SetValues(ISomething thing) ;
    }
