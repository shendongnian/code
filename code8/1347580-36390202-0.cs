    [HttpGet]
    public ActionResult LogIn()
    {
      Viewbag.ReturnURL = Request.UrlReferrer.ToString();
      return View();
    }
    
    [HttpPost]
    public ActionResult LogIn(string token, string returnURL)
    {
      using (Model model = new Model())
        if (model.Users.Any(_ => _.Token == token))
          return Redirect(returnURL);
      return View();
    }
