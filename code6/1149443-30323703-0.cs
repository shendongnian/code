    var viewAddressModel = new Address();
    .... // set values
    if (!TryValidateModel(viewAddressModel))
    {
      if (model.OwnOrRent != "1" || model.OwnOrRent != "9")
      {
        if (ModelState.ContainsKey("HomeValue"))
        {
          ModelState["HomeValue"].Errors.Clear();
        }
        if (ModelState.ContainsKey("PurchasePrice"))
        {
          ModelState["PurchasePrice"].Errors.Clear();
        }
      }
    }
