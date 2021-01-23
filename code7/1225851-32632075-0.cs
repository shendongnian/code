    protected void Session_Start(object sender, EventArgs e)
    {
         if(!UserIsInDatabase(HttpContext.Current.User.Identity.Name))
         {
             AddUserToDatabase(HttpContext.Current.User.Identity.Name);
         }
    }
