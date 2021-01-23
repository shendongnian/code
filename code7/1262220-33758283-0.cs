    public ActionResult MyMethod (IEnumerable<MyViewModel> model)
    {
      foreach(var product in model)
      {
        //You can access each property here
       //product.AString
      }
    }
