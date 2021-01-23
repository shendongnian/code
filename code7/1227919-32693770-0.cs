    public IList<User> GetUser(UserRequest req){
        //remove the [if(req.identityLst!=null)] part
    }
    
    public bool ContainsIdentity(IList<string> x, IList<string> y)
    {
        if( x == null || y == null ) return false;
        return x.Any(test => y.Contains(test));
    }
    var users = GetUser(req).ToList();
    var filtered = users.Where( u => ContainsIdentity(u.identity.Split(','), req.identityLst ));
