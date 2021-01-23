    public static List<UserPrincipal> GetInactiveUsers(TimeSpan inactivityTime)
    {
        List<UserPrincipal> users = new List<UserPrincipal>();
        using (Domain domain = Domain.GetCurrentDomain())
        {
            foreach (DomainController domainController in domain.DomainControllers)
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domainController.Name))
                using (UserPrincipal userPrincipal = new UserPrincipal(context))
                using (PrincipalSearcher searcher = new PrincipalSearcher(userPrincipal))
                using (PrincipalSearchResult<Principal> results = searcher.FindAll())
                {
                    users.AddRange(results.OfType<UserPrincipal>().Where(u => u.LastLogon.HasValue));
                }
            }
        }
        return users.Where(u1 => !users.Any(u2 => u2.UserPrincipalName == u1.UserPrincipalName && u2.LastLogon > u1.LastLogon))
            .Where(u => (DateTime.Now - u.LastLogon) >= inactivityTime).ToList();
    }
