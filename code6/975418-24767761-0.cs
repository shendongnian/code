    public ActionResult EFtest()
    {
        IntelliBase.Models.IntelliBaseEntities db = new Models.IntelliBaseEntities();          
        var items = db.Tasks.ToList();
        return View(items);
    }
