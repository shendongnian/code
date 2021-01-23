    public ActionResult Add(string id)
    {
        ViewBag.ModelId = id;
        return View();
    }
    
    [HttpPost]
    public ActionResult Add(List <class_of_data> classList, string id)
    {
    // you can set int id if you need it as an number since MVC will convert it.
    // Also keep in mind that class in a reserved keyword. Changed it to classList 
    // DO SOME STUFF
    }
