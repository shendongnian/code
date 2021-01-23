    [HandleError(View = "Error")]
    public ActionResult Index()
    {
        ViewBag.Message = "Welcome to ASP.NET MVC!";
        int u = Convert.ToInt32("");// Error line
        return View();
    } 
