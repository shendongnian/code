    public string LoginAdmin(string username, string password)
    {
        var user = GlobalVariables.allAdmin
                     .FirstOrDefault(x => x.getName() == username && x.GetPassword() == password);
    
        if(user==null) throw new AuthorizationException("...")
    
        var result = GlobalVariables.allAdmin.IndexOf(user);
    
        return result;
    }
