    public class UserManager : UserManager<User, int>
    {
    	public UserManager(IUserStore<User, int> store): base(store)
    	{
    	    this.Store = store;
    	}
    
    	public IUserStore<User, int> Store { get; set; }
    
    }
