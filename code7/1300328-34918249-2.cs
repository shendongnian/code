    public IList<IApplicationUserRole<Role>> Roles
    {
        get
        {
            return _account.Roles.Select(r=> 
                   new ApplicationUserRole<Role>() {Name = r})
                   .Cast<IApplicationUserRole<Role>>()
                   .ToList(); 
        }
    }
