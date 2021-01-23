    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            Label1.Text = User.Identity.Name; // username
        }
        else
        {
            Label1.Text = "Guest User";
        }
    }
