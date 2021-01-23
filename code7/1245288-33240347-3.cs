    protected void Application_AuthorizeRequest(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated && Roles.Enabled)
        {
            Context.User = new CustomPrincipal((WindowsIdentity)User.Identity);
        }
    }
