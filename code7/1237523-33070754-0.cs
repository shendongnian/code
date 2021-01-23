            protected void Page_Load(object sender, EventArgs e)
    {
        var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        var currentUser = manager.FindById(Context.User.Identity.GetUserId());
        HyperLink h = ((HyperLink)this.loginViewMaster.FindControl("ManageLink"));
        if(currentUser != null)
        {
            h.Text = "Hello, " + currentUser.FirstName + " " + currentUser.LastName;
        }
    }
