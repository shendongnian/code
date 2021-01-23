    public ActionResult _NewEmpFifth()
    {
        IEnumerable<SelectListItem> departments = new List<SelectListItem>();
        using (EIPInternalEntities ctx = new EIPInternalEntities())           
        {                              
            ViewBag.Department = new SelectList(ctx.Database.SqlQuery<GetDepartment>("EXEC dbo.uspGetDepartments").ToList(), "DepartmentID", "Department");        
        }
        var sessionValues = Session["MySessionValues"] as MySessionValues;
        return PartialView();
    }
