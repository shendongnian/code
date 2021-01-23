    public class MyUser 
    {
    	private readonly ClaimsIdentity _identity;
    	
        public SeaUser(ClaimsIdentity identity)
    	{
    		_identity= identity;
    	}
    
    	public IEnumerable<Claim> Claims { get { return _identity.Claims; } }
    }
    
    public abstract class BaseController : ApiController
    {
    	private MyUser _user;
    
    	public new MyUser User
    	{
    		get 
            { 
                return _user ?? (_user = User.Identity != null 
                                      ? new MyUser((ClaimsIdentity)User.Identity) 
                                      : null); }
    	    }
        }
    }
