    public IEnumberable<UserPrincipal> GetUsersFromGroups(string[] groupNames)
    {
        using (var ctx = new PrincipalContext(ContextType.Domain))
        {
            foreach (var groupName in groupNames)
            {
                foreach (var userPrincipal in GroupPrincipal.FindByIdentity(ctx, groupName)
                                                   .GetMembers())
                {
                    yield return userPrincipal;
                }
                 
            }       
    
        }
    }    
