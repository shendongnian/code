    public ActionResult EditAge(int id, AgeViewModel model)
    {
        UpdateStudent(id, age: model.Age);
        return View();
    }
    public ActionResult EditName(int id, NameViewModel model)
    {
        UpdateStudent(id, name: model.Name);
        return View();
    }
    ...
    protected void UpdateStudent(int id, string name = null, int? age = null)
    {
        var student = db.Students.Find(id);
        if (name != null)
        {
            student.Name = name;
        }
        if (age.HasValue)
        {
            student.Age = age.Value;
        }
        
        db.Entry(student).State = EntityState.Modified;
        db.SaveChanges();
    }
