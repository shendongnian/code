    public IActionResult Index()
    {
        var model = new PersonViewModel();
        model.FirstName = "Frank";
        model.LastName = "Underwood";
        var emailbody = base.RenderPartialViewToString("Templates/RegistrationTemplate", model);
    
        return View();
    }
