	public class ClassWithPrivateTryCatchCallWrapper
	{
		IExternalLibCaller externalLibCaller;
		
		public ClassWithPrivateTryCatchCallWrapper(IExternalLibCaller externalLibCaller)
		{
			this.externalLibCaller = externalLibCaller;
		}
		
		private T SafeCallWithLogin<T>(Func<T> method)
	    {
	    	externalLibCaller.SafeCall(() =>
	    	{
	    		Login();
	            return method();
	    	})
	    }
		
		//use: SafeCallWithLogin(method)
		//insted: TryCatchCallWrapper(method);
	}
	
	public interface IExternalLibCaller
	{
		T SafeCall<T>(Func<T> method)
	}
	
	public class ExternalLibCaller : IExternalLibCaller
	{
	    public T SafeCall<T>(Func<T> method)
	    {
	        try
	        {
	            return method();
	        }
	        catch (ConnectionException e)
	        {
	            switch (e.ConnectionReason)
	            {
	                case ConnectionReasonEnum.Timeout:
	                    throw new ...
	            }
	        }
	        catch (XException e)
	        {
	            throw ...
	        }
	    }
	}
