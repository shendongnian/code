    using Microsoft.AspNet.SignalR;
    
    namespace YourServer
    {
    	public class UserIdProvider : IUserIdProvider
    	{
    		public string GetUserId(IRequest request)
    		{
    			return request.Headers.Get("windowsName");
    		}
    	}
    }
