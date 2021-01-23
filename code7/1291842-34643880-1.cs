    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
    {
        // find a user
        using (var group = GroupPrincipal.FindByIdentity(ctx, "groupName"))
    	{
    		if (group == null)
    		{
    			MessageBox.Show("Group does not exist");
    		}
    		else
    		{
    			var users = group.GetMembers(true);
    			foreach (UserPrincipal user in users)
    			{
    			    //user variable has the details about the user 
    			}
    		 } 
    	  }
    }
