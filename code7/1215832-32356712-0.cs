    private static Dictionary<Tuple<string, string>, bool> groupIdentityCache = new Dictionary<Tuple<string, string>, bool>();
..
    public static bool UserHasRole(IIdentity identity, string groupShortName)     
    {
    	// (we rename our actual AD roles to shorter ones relevant to the site
     	// e.g. [MyAuthorizeAttribute(Roles = "Support,Admin")])
    	if (!AdLongGroupNames.ContainsKey(groupShortName.ToUpper())) return false;
    	string fullADGroupName = AdLongGroupNames[groupShortName.ToUpper()];            
    	Tuple<string, string> key = new Tuple<string, string>(identity.Name.ToUpper(), groupShortName.ToUpper());
	    if (!groupIdentityCache.ContainsKey(key))
    	{
    		using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "DOMAINNAME"))      
    		{
    			using (GroupPrincipal groupPrincipal = GroupPrincipal.FindByIdentity(principalContext, fullADGroupName))
    			{
    				using (UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(principalContext, GetLogin(identity)))
    				{
    					groupIdentityCache[key] = userPrincipal.IsMemberOf(groupPrincipal);
    				}
    			}
    		}                
    	}            
    	return groupIdentityCache[key];
    }
    public static string GetLogin(IIdentity identity)
    {
    	string[] parts = identity.Name.Split('\\');
    	if (parts.Count() < 2) return parts[0]; else return parts[1];
    }
