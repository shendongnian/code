    [HttpPost]
    public ActionResult Create(Parent model)
    {
    
       var newChildren = model.Children.Where(s => !s.IsDeleted && s.ChildId == 0);
    
       var updated = model.Children.Where(s => !s.IsDeleted && s.ChildId != 0);
    
       var deletedChildren = model.Children.Where(s => s.IsDeleted && s.ChildId != 0);
    
    
        return View(model);
    }
