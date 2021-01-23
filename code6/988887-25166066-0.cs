    public ActionResult Details(string id = null)
    {
         Assignment assignment = db.Assignments.Find(id);
    
         if (assignment == null)
         {
             return HttpNotFound();
         }
    
         return File(assigment.FileLocation, "content/type", "fileName.extension");
    }
