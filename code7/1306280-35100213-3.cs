    public ActionResult KaminniTopky(int? id)
    {
       if (!id.HasValue)
       {
          return View();
       }
       else
       {
          return View("OtherViewName");
       }
    }
