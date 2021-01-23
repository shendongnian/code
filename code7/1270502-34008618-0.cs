    public ActionResult FirstPage()
    {
      TempData["Visitied"] = true;
    }
    
    public ActionResult SecondPage()
    {
      if(TempData["Visitied"] != null)
        {
           //Do your logic. Clear the temp data if needed.
           return View("SecondPage");
        }
       return View("FirstPage");
    }
