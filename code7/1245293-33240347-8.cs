    protected void Application_AuthorizeRequest(object source, EventArgs e)
    {
        if(User.Identity.IsAuthenticated && Roles.Enabled)
        {
            using (EntityContext db = new EntityContext ())
            {
                var user = db.Users.Include("Roles").SingleOrDefault(u => u.ADName.Equals(User.Identity.Name));
                if (user == null)
                    return;
            PcsPrincipal principal = new PcsPrincipal((WindowsIdentity)User.Identity, user);
                Context.User = principal;
            }
        }            
    }
