    // Vaidate credentials
    using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
    {
        return context.ValidateCredentials(userName, password);
    }
    // To get user groups
    using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
    using (UserPrincipal user = UserPrincipal.FindByIdentity(context, userName))
    {
        return user.GetAuthorizationGroups();
    }
