        public static void SetPrimaryGroup(string username, string groupname)
        {            
             var ctx = new PrincipalContext(ContextType.Domain);
             var group = GroupPrincipal.FindByIdentity(ctx, groupname);
             var user = UserPrincipal.FindByIdentity(ctx, username);
    
             string sid = group.Sid.Value;
             int newPrimaryGroupId = Convert.ToInt32(sid.Substring(sid.LastIndexOf('-')+1));
             var userEntry = user.GetUnderlyingObject() as DirectoryEntry;
             userEntry.Properties["primaryGroupID"].Value = newPrimaryGroupId;
             userEntry.CommitChanges();
        }
