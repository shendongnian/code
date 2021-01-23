    public ActionResult LoadVMView(){      
         var model = new VM();
         var items = GetSitesFromDatabase().Select(s => new SelectListItem(){
                            Text = s.SiteName,
                            Value = s.ID.ToString()
                            });
     model.SiteList = new SelectList(items);
                
          return View(model);
    }
