    using(PrincipalContext context = new PrincipalContext(ContextType.Domain))
    {
        UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, Username);
        //? - to mark DateTime type as nullable
        DateTime? pwdLastSet = (DateTime?)user.LastPasswordSet;
        int delta = 7;
        if (pwdLastSet != null)
        {
            if (DateTime.Compare((DateTime)pwdLastSet, DateTime.Now) < delta)
            {
                //send email
                ...
            }
        }
    }
