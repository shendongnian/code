    public class User : IPrincipal
    {
        private readonly IPrincipal _user;
        public IIdentity Identity { get; private set; }
        public User (IPrincipal user)
    	{
            Identity = user.Identity;
            _user = user;
    	}
     
    	public bool IsInRole(string role)
    	{
    		return _user.IsInRole(role);
    	}
    }
