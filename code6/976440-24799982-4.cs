    [HttpGet]
    public ActionResult Create()
    {
      ClientVM model = new ClientVM();
      model.Client = new Client();
      model.RestrictionList = GetRestrictions(); // your code to return the select list
      return View("Edit", model);
    }
    [HttpGet]
    public ActionResult Edit(int ID)
    {
      ClientVM model = new ClientVM();
      model.Client = // call database to get client based on ID
      model.RestrictionList = GetRestrictions();
      return View(model);
    }
    [HttpPost]
    public ActionResult Edit(ClientVM model)
    {
      if (!ModelState.IsValid)
      {
        model.RestrictionList = GetRestrictions();
        return View(model);
      }
      Client client = model.Client;
      // Save and redirect
      ....
    }
