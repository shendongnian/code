    string sid = "";
    using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
    {
        UserPrincipal user = UserPrincipal.Current;
        //sid = user.SamAccountName;
        sid = user.UserPrincipalName;
        //sid = user.Sid.ToString();
    
        DirectoryEntry entry = user.GetUnderlyingObject() as DirectoryEntry;
    
        entry.RefreshCache(new[] {"employeeNumber"});
    
        if (entry.Properties.Contains("employeeNumber"))
        {
            
        }
    }
