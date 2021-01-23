    public List<string> GetAllEmailsFromUsersContainer()
    {
        List<string> users = new List<string>();
        
        // create your domain context and bind to the standard CN=Users
        // container to get all "standard" users
        using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, null, "CN=Users,dc=YourCompany,dc=com"))
        {
            // define a "query-by-example" principal - here, we search for a UserPrincipal 
            // which is not locked out, and has an e-mail address	
            UserPrincipal qbeUser = new UserPrincipal(ctx);
            qbeUser.IsAccountLockedOut = false;
            qbeUser.EmailAddress = "*";
            // create your principal searcher passing in the QBE principal    
            PrincipalSearcher srch = new PrincipalSearcher(qbeUser);
            // find all matches
            foreach(var found in srch.FindAll())
            {
                users.Add(found.EmailAddress);
            }
        }
        
        return users;
    }
