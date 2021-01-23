    public ActionResult GeneratePDF()
    {
      var model = new GeneratePDFModel();
      //get content
      return View(model);
    }
