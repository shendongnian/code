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
    	public static int previousIdentity = 0;
    	public static int GetNext()
    	{
    		return ++previousIdentity;
    	}
    }
