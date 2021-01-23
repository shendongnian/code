    public ActionResult QuickEdit(int pk, string name, string value)
    {
        var pext = Db.ProjectExtensions.Find(pk); 
        if (ModelState.IsValid)
        {
            var propertyInfo = pext.GetType().GetProperty(name); //get property
            if (propertyInfo != null)
                    {
                        var type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                        var safeValue = (value == null) ? null : Convert.ChangeType(value, type);
                        propertyInfo.SetValue(pext, safeValue, null);
                    }
            Db.SaveChangesWithHistory(LoggedEmployee.EmployeeId);
    
            return Content("");
        }
    }
