    public ActionResult Save(Student s) {
       var record = _db.Students.Find(s.Id);
       if(record != null) {
          bool isFullEdit = record.EditMode == StudentEditMode.Full;
          if (isFullEdit || record.EditMode == StudentEditMode.Name)
             record.Name = s.Name;
          if (isFullEdit || record.EditMode == StudentEditMode.NickName)
             record.NickName = s.NickName;
          if (isFullEdit || record.EditMode == StudentEditMode.Age)
              record.Age = s.Age;
          if (isFullEdit || record.EditMode == StudentEditMode.Address)
              record.Address = s.Address;
          _db.SaveChanges();
       }
       return RedirectToCurrentUmbracoUrl():
     }
