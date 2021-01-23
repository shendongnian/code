    private string NewPass()
    {
        UserManager<IdentityUser> userManager =
            new UserManager<IdentityUser>(new UserStore<IdentityUser>());
    
        /// Fetch the user object
        IdentityUser user = (from x in db.AspNetUsers
                         where x.Email == txtEmail.Text
                         select x).SingleOrDefault();
        return user != null ? user.Id : String.Empty;
    }
