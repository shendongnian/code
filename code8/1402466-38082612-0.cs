    public ActionResult MyAction()
    {
      /// ... code
      if (Request.IsAuthenticated)
      {
        return RedirectToAction("index", "home");
      }
      return View();
    }
