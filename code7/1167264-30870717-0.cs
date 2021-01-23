    public static class MyModule
    {
    	private static int iCount = 0;   // this is private, so not accessible outside this class
    	
    	public static void Increment()
    	{
    		iCount++;
    	}
    	
    	public static bool CheckModulus()
    	{
    		return iCount % 6 == 0;
    	}
    }
