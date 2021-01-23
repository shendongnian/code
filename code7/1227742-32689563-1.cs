    void UseUserPrincipalExtension(Identity type, string identity, 
                                   Action<UserPrincipalExtension> action)
    {
      using (PrincipalContext pc = MyUtilities.GetPrincipalContext())
      using (UserPrincipalExtension UPE = 
             UserPrincipalExtension.FindByIdentity(pc, type, identity))
      {
        action(UPE);
      }
    }
