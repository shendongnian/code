    [HttpPost]
    public virtual ActionResult Index(CreatePostVm model)
    {
      if (ModelState.IsValid == false)
      {
         ModelState["PostTitle"].Value =
              new ValueProviderResult(string.Empty, string.Empty,CultureInfo.InvariantCulture);
         return View(model);
      }
      // to do : Return something
    }
