    public ActionResult MyAction()
    {
        // a simple example 
        return View(new MyViewModel{ InputFiles = new InputFiles[10] });
    }
    [HttpPost]
    public ActionResult MyAction(MyViewModel model)
    {
        var myFile=model.InputFiles[0];
    }
