    //GET THE USER FROM DOMAIN B
    using (UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(domainContext, UPN))
    {
        if (userPrincipal != null)
        {
           //FIND THE GROUP IN DOMAIN A
           using (GroupPrincipal groupPrincipal = GroupPrincipal.FindByIdentity(domainContext, groupName))
           {
              if (groupPrincipal != null)
              {
                 //CHECK TO MAKE SURE USER IS NOT IN THAT GROUP
                 if (!userPrincipal.IsMemberOf(groupPrincipal))
                 {
                    string userSid = string.Format("<SID={0}>", userPrincipal.SID.ToString());
                    DirectoryEntry groupDirectoryEntry = (DirectoryEntry)groupPrincipal.GetUnderlyingObject();
                    groupDirectoryEntry.Properties["member"].Add(userSid);
                    groupDirectoryEntry.CommitChanges();
                  }
               }
            }
         }
     }
