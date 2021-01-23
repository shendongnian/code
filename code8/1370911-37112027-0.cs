    public ActionResult LogOn(LogOnModel model, string returnUrl, string view = string.Empty)
    {
      // Your code here and then write below condition
      if(view == "External")
         return RedirectToAction("Extension/LogOn");
      else
         return View(model);
    
    }
