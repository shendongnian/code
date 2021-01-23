    [ChildActionOnly]
    public PartialViewResult _RequestPartial()
    {
          ... code that populates model you want to pass ...
    
          return PartialView(model);
    }
    [ChildActionOnly]
    public PartialViewResult _LoginPartial()
    {
          ... code that populates model you want to pass ...
    
          return PartialView(model);
    }
