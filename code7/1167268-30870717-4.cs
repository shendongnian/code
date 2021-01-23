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
        // this part in response to the question about async methods
        // not part of the original module
        public async static Task<int> GetIntAsync()
        {
        	using (var ms = new MemoryStream(Encoding.ASCII.GetBytes("foo"))) 
    	    {
    		    var buffer = new byte[10];
        		var count = await ms.ReadAsync(buffer, 0, 3);
        		return count;
    	    }
        }
    }
