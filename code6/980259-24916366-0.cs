    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Home page for " + User.Identity.Name;
        }
        else
        {
            Page.Title = "Home page for guest user.";
        }
    }
