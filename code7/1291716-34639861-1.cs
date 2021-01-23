    DateTime expiryDate;
    if (!DateTime.TryParse(model.ExpiryDate, out expiryDate))
    {
        ModelState.AddModelError("", string.Format(
            "The given ExpiryDate '{0}' was not valid", model.ExpiryDate));
    } 
