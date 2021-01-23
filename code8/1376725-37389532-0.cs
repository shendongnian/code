    public ActionResult Index(int? parameter1)
    {
      if(string.IsNullOrEmpty(parameter1)
        return RedirectToAction("action1", "controller1", new {@id = "knownValue"});
      else
      {
        //whatever action you wanted to do based on value in parameter1
      }
    }
