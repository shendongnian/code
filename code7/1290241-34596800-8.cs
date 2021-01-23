    [HttpPost]
    public ActionResult Index(SearchVm model)
    {
       foreach(var f in model.Filters)
       {
         //check f.Property.SqlColumn, f.Value & f.Operator            
       }
      // to do :Return something useful
    }
