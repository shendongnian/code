    public ActionResult DeleteNamelist(string nameToDelete)
    {
        NameModel.listOfNames.RemoveAll(x => x == nameToDelete);
        return View("NameInput", NameModel.listOfNames);
    }
