    public ActionResult DeleteNamelist(string nameToDelete)
    {
        return View("NameInput", NameModel.listOfNames.Where(x => x != nameToDelete));
    
    }
