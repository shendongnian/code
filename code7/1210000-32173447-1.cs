    public ActionResult Create()
    {
      BookingVM model = new BookingVM();
      ConfigureCreateModel(BookingVM model);
      return View(model);
    }
    // common code for initializing select lists etc
    public void ConfigureCreateModel(BookingVM model)
    {
      model.OpticianList = db.Opticans.Select(o => new SelectListItem()
      {
        Value = o.OpticianId,
        Text = o.User.FullName
      }
      .... // other select lists
    }
