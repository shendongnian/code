    public static UserPrincipalExtension GetUPE(Identity type, string identity)
    {
         UserPrincipalExtension UPE = null;
         using (PrincipalContext pc = MyUtilities.GetPrincipalContext())
         {
            UPE = UserPrincipalExtension.FindByIdentity(pc, type, identity));
         }
         return UPE;
    }
