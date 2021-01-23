    using (var principalContext = new PrincipalContext(ContextType.Domain))
    {
    	using (var userPrincipal = new UserPrincipal(principalContext))
    	{
    		userPrincipal.SamAccountName = 'userdomain name'; // -> ex. jtabuloc
    
    		using (var principalSearcher = new PrincipalSearcher())
    		{
    			principalSearcher.QueryFilter = userPrincipal;
    
    			var principal = principalSearcher.FindOne();
    
    			if (principal != null)
    			{
    				var directoryEntry = (DirectoryEntry)principal.GetUnderlyingObject();
    
                     // You can examine directoryEntry if key exist and retrieve values                   
    				 var Name = directoryEntry["name"][0] as string;
                     var FullName = directoryEntry["FullName"][0] as string;
                     var Email = directoryEntry["mail"][0] as string;
                     var Title = directoryEntry["title"][0] as string;
    			}    
    		}
    	}
    }
