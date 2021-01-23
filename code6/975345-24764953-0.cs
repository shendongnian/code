    private List<string> ProcessAuthorizationRoles(string[] pDefinedRoles, CustomIdentityClass pIdentity)
    {
        return (from role in (from r in pDefinedRoles
                              select new
                              {
                                  Partial = string.Format(":{0}", r)
                              })
                from r in pIdentity.Roles
                where r.Contains(role.Partial)
                select r).ToList();
    }
