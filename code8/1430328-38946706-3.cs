    [HttpPost]
    public ActionResult Create(CreateSiteVm model)
    {
      if(ModelState.IsValid)
      {
        var e=new Site { Name = model.Name, Description = model.Description};
        e.TypeMenuId = model.TypeMenuId;
    
        var arr = model.Tags.Split(',');
        foreach (var s in arr)
        {
          e.Tags.Add(new Tag { Name = s});       
        }
        dbContext.Sites.Add(e);
        dbContext.SaveChanges();
        return RedirectToAction("Index");
      }
      //to do : Load the dropdown again same as GET
      return View(model);  
    }
