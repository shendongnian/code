    public static bool ActiveDirectoryGroupMembershipOk(string userid, string groupName)
    {
    	bool membershipOk = false;
    	using (var pc = new PrincipalContext(ContextType.Machine, "my_pc_name"))
    	{
    		using (var p = Principal.FindByIdentity(pc, IdentityType.SamAccountName, userid))
    		{
    			// if user account exists, check the group membership
    			if(p != null)
    			{
    				System.Security.Principal.WindowsIdentity wi = new System.Security.Principal.WindowsIdentity(userid);
    				System.Security.Principal.WindowsPrincipal wp = new System.Security.Principal.WindowsPrincipal(wi);
    				membershipOk = wp.IsInRole(groupName);
    			}
    		}
    	}
    	return membershipOk;
    }
