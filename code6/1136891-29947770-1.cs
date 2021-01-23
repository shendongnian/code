    public ActionResult LoadVMView(){      
         var model = new VM();
         model.SiteList = GetListFROMDB().Select(s => new SelectListItem(){
                            Text = s.SiteName,
                            Value = s.Id
                            }).ToList()
                
          return View(model);
    }
