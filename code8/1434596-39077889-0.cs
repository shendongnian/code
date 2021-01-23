    protected void Page_Load(object sender, EventArgs e)
    {
        // First find if user is logged in
        if (Context.User.Identity.IsAuthenticated)
        {
            // Finds user name and says Welcome 
            lblWelcome.Text = "Welcome " + Context.User.Identity.Name;
        }
        else
        {
            // It is anonymous user, say Welcome  to guest
            lblWelcome.Text = "Welcome guest";
        }
    }
