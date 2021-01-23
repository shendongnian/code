    [HttpGet]
    public ActionResult FileUpload(string errorMessage)
    {
       @ViewBag.Error = errorMessage;
       . . .
       return View(p);
    }
