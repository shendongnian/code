    public void GetUserName()
    {
        string userName = HttpContext.Current.User.Identity.Name;
        Response.Write(userName.ToString());
    }
