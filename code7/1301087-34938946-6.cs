    MainVM model = new MainVM
    {
      SelectedDay = "Monday", // set this if you want a default button selected
      Days = db.DeliveryPeriods.Select(c => new DeliveryDateVM()
      { 
        Id = c.Id, 
        DeliveryDay = c.DeliveryDay, 
        DeliveryType = c.DeliveryType,
      }).ToList()
    }
    return View(model);
      
