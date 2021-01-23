    public ActionResult Contact()
    {
      EmailFormModel model = TempData["EmailFormModel"] == null ? new EmailFormModel() : (EmailFormModel) TempData["EmailFormModel"]; 
      ViewBag.Message = "Your contact page.";
      return View(model);
    }
