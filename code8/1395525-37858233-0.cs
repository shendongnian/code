    public ActionResult Basic()
    {
        var person = new Person
        {
            firstName = "Adam",
            surName = "Andersen"
        };
        return View(person);
    }
