    private string NewPass()
    {
    UserManager<IdentityUser> userManager =
        new UserManager<IdentityUser>(new UserStore<IdentityUser>());
    string userId = (from x in db.AspNetUsers
                     where x.Email == txtEmail.Text
                     select x.Id).FirstOrDefault().Id;
    return userId;
    }
