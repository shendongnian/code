    public IActionResult Index()
        {
            return View(_context.CourseLecturers
           .Include(c => c.Courses).Include(c => c.Lecturers).ToList());
        }
