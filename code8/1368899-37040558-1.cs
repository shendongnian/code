    void Main()
    {
    	var thing = new MyBadThing(); 
    	thing.GetBoss()?.FireSomeone();
    }
    
    public class MyBadThing
    {
    	public class Boss
    	{
    		public void FireSomeone() 
    		{ 
    			throw new NullReferenceException();
    		}
    	}
    	public Boss GetBoss()
    	{
    		return new Boss();
    	}
    }
