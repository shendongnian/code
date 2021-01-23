    protected ActionResult redirectMethod(Exception e)
    {
        //Using e for logging methods
        return RedirectToAction("Error", "Home");
    }
    public ActionResult Index()
    {
        try
        {
            <!-- try statement -->
        }
        catch (Exception e)
        {
            return redirectMethod(e);
        }
        return View();
    }
