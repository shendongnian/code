    public ActionResult ListNames()
    {
        var listNames = new MVC_1.Models.ListNames();
        ViewBag.Name = listNames.names[0];
        return View(listNames);
    }
