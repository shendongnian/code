    public ActionResult Activités()
    {
        var model = new ModelDeBase { Slider = this.Actualities };
        return View(model);
    }
