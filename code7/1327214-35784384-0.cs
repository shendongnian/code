    DisplayStudent(int? id)
    {
        db.dispose();
        db = new dbEntities();
        var student = db.Studen.Find(id);
        ViewBag.Teachers = db.Teacher.Where(model => model.studentId ==id).ToList();
        return View(student);
    }
