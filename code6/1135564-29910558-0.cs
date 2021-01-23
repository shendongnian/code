    protected void CreateUserWizard_CreatedUser(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Profile.Initialize(CreateUserWizard.UserName,true);
            MembershipUser newUser = System.Web.Security.Membership.GetUser(CreateUserWizard.UserName);
            Profile.UserName = newUser.UserName;     // Get and Set the user name after sign up.
            Guid Id = (Guid)newUser.ProviderUserKey; // Get the UserId after sign up.
            Profile.UserId = Id;                     // Set the UserId after sign up.
        }
    }
