    [HttpPost]
    public ActionResult Register(string name)
    {
      // to do :Do something with posted data
      return RedirectToAction("FormSubmitted");
    }
    public ActionResult FormSubmitted()
    { 
      return View();
    }
