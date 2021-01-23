    public ActionResult Index()
    {
        bool succeeded = MyHelper.SomeFunction(); // This method should never throw
        if (succeeded)
            return View(); // No view name specified means this renders "Index"
        else
            return View("Error");
    }
