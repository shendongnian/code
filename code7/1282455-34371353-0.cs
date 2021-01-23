    public ActionResult DeleteNamelist(string nameToDelete)
    {
        int numRemoved = NameModel.listOfNames.RemoveAll(x => x == nameToDelete);
        return View("NameInput", numRemoved);
    }
