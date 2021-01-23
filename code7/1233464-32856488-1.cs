    Delivery delivery = // get your data model
    DeliveryVM model = new DeliveryVM
    { 
      ID = ... // set other properties based on data model
    };
    // Build list of options basd on current status
    List<string> options = new List<string>();
    if (delivery.Status == Status.Created)
    {
      model = Status.Dispatched; // its the only choice so set as the default selection
      options.Add(Status.Dispatched.ToString());
    }
    else if (delivery.Status == Status.Dispatched)
    {
      options.Add(Status.Delivered.ToString());
      options.Add(Status.Delayed.ToString());
    }
    else if (delivery.Status == Status.Delayed)
    {
      options.Add(Status.Dispatched.ToString());
      options.Add(Status.Delivered.ToString());
    }
    model.StatusList = new SelectList(options);
    return View(model);
