    public ActionResult Create()
    {
        ViewBag.identifier = new SelectList(db.databaseName, "Id", "ProductColour");
    }
    [HttpPost]
    public ActionResult Create([Bind(Include = "Id, ProductColour")] #modelName identify)
    {
        ViewBag.identifier = new SelectList(db.databaseName, "Id", "ProductColour", identify.Id);
    }
