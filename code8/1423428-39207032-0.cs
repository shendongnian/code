    public class SuppressedThread : Thread
    {            
    	protected override void Finalize()
    	{
    		 try
    		 {
    		  // kill what you want
    		 }
    		 finally
    		 {
    		  base.SupressFinalizeFinalize();
    		 }
    	}
    }
    
    public class SuppressedThread : Thread, IDisposable
    {    
    	protected override void Dispose()
    	{
    		 try
    		 {
    		  // kill what you want
    		 }
    		 finally
    		 {
    		  GC.SupressFinalize();
    		 }
    	}
    }
