    [HttpPost]
    public ActionResult Gender(WelcomeVm model)
    {
       model.Genders = new List<SelectListItem>
       {
             new SelectListItem { Value="Male", Text="Male"},
             new SelectListItem { Value="Female", Text="Female"}
       };
       return View(model);
    }
