    public class ProfileController : Controller
    {
    	private readonly MyClient _client;
    
    	public ProfileController()
    	{
    		var clientInfo = Resolve<IClientInfo>(); // call out to your service locator
    		_client = clientInfo.GetClient();
    	}
    }
    
    public interface IClientInfo
    {
    	MyClient GetClient();
    }
    
    public interface IAuth
    {
    	System.Security.Claim GetSidClaim();
    }
    
    public class ClientInfo : IClientInfo
    {
    	private readonly IAuth _auth;
    
    	public ClientInfo(IAuth auth)
    	{
    		_auth = auth;
    	}
    
    	public MyClient GetClient()
    	{
    		var apiKey = ApiKey;
    		var client = new MyClient(apiKey);
    		var claim = _auth.GetSidClaim();
    		client.AddCredentials(claim.Value);
    
    		return client;
    	}
    
    	protected virtual string ApiKey
    	{
    		get { return ConfigurationManager.AppSettings["APIKey"]; }
    	}
    }
