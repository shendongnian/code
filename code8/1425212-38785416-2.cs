    public class Test
    {
    	private static int mIndex = 0; // this parameter will be incremented for each new Test
    	private int mId =0; // this parameter will hold the last incremented value
    	
    	public Test()
    	{
    		mId = ++mIndex; // mIndex++ if you want to start with 0
    	}
    	
    	public int Id
    	{
    		get{ return mId;}
    	}
    }
