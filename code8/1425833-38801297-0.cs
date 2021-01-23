    using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "domainname"))
    {
        UserPrincipal yourUser = UserPrincipal.FindByIdentity(context, EmailAddress);
        if (yourUser != null)
        {
            user.FirstName = result.GivenName;
            user.LastName = result.Surname;
        }
    }
