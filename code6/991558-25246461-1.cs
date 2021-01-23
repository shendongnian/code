    using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "domain.com"))
    {
        using (UserPrincipal user = UserPrincipal.FindByIdentity(pc, "Doe, John"))
        {
            Console.Out.Write(user.Enabled);
        }
    }
