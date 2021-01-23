    public JsonResult fileInDb(string eId) //change signature to string and then convert to int 
    {
        int empId=Convert.ToInt32(eId);
        using (SLADbContext db = new SLADbContext())
        {
             bool file = db.CompetenceUploads.Any(x => x.EmployeeId == empId);
             if (file)
             {
                 return Json(new { result = true },JsonRequestBehavior.AllowGet);
             }
             else
             {
                 return Json(new { result = false}JsonRequestBehavior.AllowGet);
             }
        }
    }  
