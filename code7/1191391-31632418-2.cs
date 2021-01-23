    public ActionResult Create()
    {
      NewThreatVM model = new NewThreatVM model();
      ConfigureViewModel(model);
      return View(model);
    }
    [HttpPost]
    public ActionResult Create(NewThreatVM model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureViewModel(model);
        return View(model);
      }
      // Initialize new data model and map properties from view model
      Threat threat = new Threat() { Description = model.Description };
      // Save it (which will set its ID property)
      _context.Threats.Add(Threat);
      _context.SaveChanges();
      // Save each selected security event
      foreach (int selectedEvent in model.SelectedSecurityEvents)
      {
        ThreatHasSecurityEvent securityEvent = new ThreatHasSecurityEvent()
        {
          ThreatID = threat.ID,
          SecurityEventID = selectedEvent
        };
        _context.ThreatHasSecurityEvents.Add(securityEvent);
      }
      _context.SaveChanges();
      return RedirectToAction("GetThreat", new { ThreatID = threat.ID });
    }
    private void ConfigureViewModel(NewThreatVM model)
    {
      var securityEvents = _context.SecurityEvents;
      model.SecurityEventList = new SelectList(securityEvents, "ID", "Description");
    }
