    [HttpPost]
    public ActionResult Create(CreateEventVm model)
    {
      if(ModelState.IsValid)
      {
        using (var db = new UltimateDb())
        {
          var event = new ClubEvent();
          event.EventDescription = model.EventDescription;
          //Set other properties also from view model.
        
          db.ClubEvents.Add(event);
          db.SaveChanges();
        }
       
        // Redirect to another action after successful save (PRG pattern)
        return RedirectToAction("SavedSuccessfully");
      }
      vm.Members =db.Members.Select(s=> new SelectListItem 
                           { Value=s.Id.ToString(),
                             Text = s.Name
                           }).ToList();
      return View(vm);
    }
