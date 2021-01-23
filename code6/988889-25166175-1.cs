    public ActionResult Details(string id = null)
    {
         Assignment assignment = db.Assignments.Find(id);
    
         return File(assigment.FileLocation, "content/type", "fileName.extension");
    }
