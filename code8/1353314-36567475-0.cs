    public ActionResult Index()
    {
        try
        {
            MyHelper.SomeMethod(); // This method is allowed to throw
            return View(); // No view name specified means this renders "Index"
        }
        catch (Exception ex)
        {
            return View("Error");
        }
    }
