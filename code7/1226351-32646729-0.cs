    public ActionResult getDepartment()
    {
       var departments = db.rms_departments.Select(x=> 
                                         new 
                                         { 
                                           dept_id=dept_id,
                                           dept_shortname=dept_shortname
                                         });
       return JSON(departments,JsonRequestBehavior.AllowGet);
    }
