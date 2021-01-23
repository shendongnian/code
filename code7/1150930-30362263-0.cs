    [HttpGet]
    public ActionResult Login()
    {
        if (Session["ContactName"] != null)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View();
        }
    }
