    public void DoTestA()
    {
    	ObjectFactory.Set<IDoesSomething, DoesSomethingBadly>();
    	
    	var doesSomething = ObjectFactory.Get<IDoesSomething>();
    	Assert.AreEqual(0, doesSomething.Add(1,1));
    }
    
    public void DoTestB()
    {
    	int expected = 42; 
    
        //This test is now *completely* dependent on DoTestA, and can give different results
        //depending on which test is run first. Further, we don't know
        //which implementation we're testing here. It's not immediately clear, even if
        //there's only one implementation.
        //As its a test, it should be very explicit in what it's testing.
        IDoesSomething foo = ObjectFactory.Get<IDoesSomething>(); 
        int actual = foo.DoesImportant(21, 21); 
    
        Assert.AreEqual(expected, actual); 
    }
    
    // Define other methods and classes here
    public class DoesSomething : IDoesSomething 
    {
        public int Add(int x, int y) 
        { 
            return x+y;
        }
    }
    
    public class DoesSomethingBadly : IDoesSomething
    {
    	public int Add(int x, int y)
    	{
    		return x-y;
    	}
    }
    
    public interface IDoesSomething
    {
        int Add(int x, int y); 
    }
