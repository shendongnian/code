    public ActionResult LoginAs()
    {
        string[] roles = (string[])TempData["data"]; 
        var model = new LoginAsViewModel
        {
            Buttons = (string[])TempData["data"]
        };
        return View(model );
    }
