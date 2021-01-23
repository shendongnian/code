    public ActionResult Details(string id = null)
    {
         Assignment assignment = db.Assignments.Find(id);
    
         return File(assignment.FileLocation, "content/type", "file.extension");
    }
