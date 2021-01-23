    public ActionResult Index(int? id)
    {
      if(id!=null)
      {
       //request came with a value for id param. Let's read it.
        var idValue =id.Value;
       //do something with the IdValue which is an Int
      }
      else
      {
        //request came without a value for id param
      }
      return View();
    }
