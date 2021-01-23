    protected void WindowsAuthentication_OnAuthenticate(object source, WindowsAuthenticationEventArgs e)
    {   
        using(EntityContext db = new EntityContext ())
        {
            var user = db.Users.SingleOrDefault(u => u.ADName.Equals(e.Identity.Name));
            HttpContext.Current.User = new PcsPrincipal(e.Identity, user);
        }
    }
