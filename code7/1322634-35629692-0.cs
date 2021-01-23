    public ActionResult Students(int? page)
    {
        var pageNumber = page ?? 1;
        var pageSize = 10;
        var totalStudents = db.Students.Count();
        var students = db.Students.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        var model = // map `students` to your view model
        var pagedList = new StaticPagedList<MyViewModel>(model, pageNumber, pageSize, totalStudents);
        return View(pagedList);
    }
