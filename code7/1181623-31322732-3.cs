    public class UserManager : UserManager<User, int>
    {
    	public UserManager(IUserStore<User, int> store): base(store)
    	{
    	    this.Store = store;
    	}
    
    	public IUserStore<User, int> Store { get; set; }
    
    	public override System.Threading.Tasks.Task<IdentityResult> CreateAsync(User user)
    	{
    		return base.CreateAsync(user);
    	}
    }
