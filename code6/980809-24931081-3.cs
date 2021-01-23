    public ActionResult Index(string name)
    {
         //Get user information and pass to view
         User userDetails = SomeLogic.GetUser(name);
         return View(userDetails);
    }
