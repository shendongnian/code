    public IActionResult Details(int id)
    {
        var course= db.Courses.FirstOrDefault(d=>d.Id==id);
        if(course==null)
        {
          return View("NotFound");
        }
        return View(course);
    }
