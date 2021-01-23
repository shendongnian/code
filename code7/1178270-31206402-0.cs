    public void UpdateLoginPanel()
    {
        if (Session["LoggedInUser"] == null) // logged out
        {
            accountMenuTitle.InnerHtml = "Log in";
        }
        else // logged in
        {
            var loggedInUser = (Customer) Session["LoggedInUser"];
            accountMenuTitle.InnerHtml = loggedInUser.Name;
        }
    }
