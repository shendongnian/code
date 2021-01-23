    [AppendModalWindow]
    public ActionResult Login(string userName, string password, bool rememberMe, string returnUrl)
    {       
       if(somecondition)
       {
          var url = ConfigurationManager.AppSettings["Redirect"];
          redirect(url);
       }
    }
