    Delivery delivery = // get your data model
    DeliveryVM model = new DeliveryVM
    { 
      ID = ... // set other properties based on data model
    };
    // Build list of options basd on current status
    List<string> options = new List<string>();
    if (delivery.Status == HealthHabitat.Models.Status.Created)
    {
      model.Status = HealthHabitat.ViewModels.Status.Dispatched; // its the only choice so set as the default selection
      options.Add(HealthHabitat.ViewModels.Status.Dispatched.ToString());
    }
    else if (delivery.Status == HealthHabitat.Models.Status.Dispatched)
    {
      options.Add(HealthHabitat.ViewModels.Status.Delivered.ToString());
      options.Add(HealthHabitat.ViewModels.Status.Delayed.ToString());
    }
    else if (delivery.Status == HealthHabitat.Models.Status.Delayed)
    {
      options.Add(HealthHabitat.ViewModels.Status.Dispatched.ToString());
      options.Add(HealthHabitat.ViewModels.Status.Delivered.ToString());
    }
    model.StatusList = new SelectList(options);
    return View(model);
