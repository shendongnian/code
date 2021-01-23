    class SimpleClass
    {
       public static readonly long A = IdentityHelper.GetNext();
       public static readonly long B = IdentityHelper.GetNext();
    
       static SimpleClass()
       {
       }
    }
    
    public static class IdentityHelper
    {
    	public static int currentIdentity = 1;
    	public static int GetNext()
    	{
    		return currentIdentity++;
    	}
    }
