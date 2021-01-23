    public ActionResult GetLogin()
    {
            string UserName = RouteData.Values.Contains("username") ? RouteData.Values["username"].ToString() : null;
            if (UserName != null)
            {
    
            }
            return View();    
    }
