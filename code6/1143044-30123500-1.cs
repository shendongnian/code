    public async Task<ActionResult> Index(int id)
    {
      var model = await SomeMethodThatGetsModelAsync(id);
      return View(model);
    }
