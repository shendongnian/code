    using (MyContext context = new MyContext)
    {
        var orgs = context.Organisation;
        foreach (Organization org in orgs)
        {
            org.Permissions = new UserPermissions()
            {
                Contacts = PermissionLevel.Locked,
                // etc
            }
        }
        context.SaveChanges();
    }
