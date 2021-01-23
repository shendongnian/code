    public ActionResult Edit()
    {
      LookUpViewModel model = new LookUpViewModel();
      ConfigureViewModel(model);
      return View(model);
    }
    [HttpPost]
    public ActionResult Edit(LookUpViewModel model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureViewModel(model);
        return View(model);
      }
      // model.SelectedLocation will contain the value of the selected location
      // save and redirect
    }
    private void ConfigureViewModel(LookUpViewModel model)
    {
      // populate your select lists
      var locations = from o in rosterManagementContext.tblCurrentLocations select o;
      model.LocationList = new SelectList(locations, "LocationId", "Location");
      .... // ditto for streams
    }
