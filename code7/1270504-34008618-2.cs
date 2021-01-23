    public ActionResult FirstPage()
    {
      TempData["Visited"] = true;
    }
    
    public ActionResult SecondPage()
    {
      if(TempData["Visited"] != null)
        {
           //Do your logic. Clear the temp data if needed.
           return View("SecondPage");
        }
       return View("FirstPage");
    }
