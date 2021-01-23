    public ActionResult Index(ModelClassHere model, string otherValue) {
        model.Liability = 10.00;
        ViewBag.Liability = model.Liability;
        return View(model); // pass model to the view
    }
