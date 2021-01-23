    [HttpGet]
    public ActionResult Search(int ID)
    {
        // do something based on the value of ID
        ViewBag.iD = ID;
        return View();
    }
