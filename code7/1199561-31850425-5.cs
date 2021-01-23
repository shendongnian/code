    public ActionResult LoginMethod(FooViewModel model)
    {
       if (model.Username == "admin" && model.Password == "admin1")
       {
         return RedirectToAction("Home");
       }
      else 
      {
         return RedirectToAction("Login");
      }
    }
