    public ActionResult QuickEdit(int pk, string name, string value)
    {
        var pext = Db.ProjectExtensions.Find(pk); 
        if (ModelState.IsValid)
        {
            var propertyInfo = pext.GetType().GetProperty(name); //get property
            propertyInfo.SetValue(pext, Convert.ChangeType(value, propertyInfo.PropertyType), null);
    
            Db.SaveChangesWithHistory(LoggedEmployee.EmployeeId);
    
            return Content("");
        }
    }
