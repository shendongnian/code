    public ActionResult Index(int? id, int? courseID,int? InstructorPage,int? CoursePage,int? EnrollmentPage)
    {
     int instructPageNumber = (InstructorPage?? 1);
     int CoursePageNumber = (CoursePage?? 1);
     int EnrollmentPageNumber = (EnrollmentPage?? 1);
     var viewModel = new InstructorIndexData();
     viewModel.Instructors = db.Instructors
        .Include(i => i.OfficeAssignment)
        .Include(i => i.Courses.Select(c => c.Department))
        .OrderBy(i => i.LastName).ToPagedList(instructPageNumber,5);
     if (id != null)
     {
        ViewBag.InstructorID = id.Value;
        viewModel.Courses = viewModel.Instructors.Where(
            i => i.ID == id.Value).Single().Courses.ToPagedList(CoursePageNumber,5);
     }
     if (courseID != null)
     {
        ViewBag.CourseID = courseID.Value;
        viewModel.Enrollments = viewModel.Courses.Where(
            x => x.CourseID == courseID).Single().Enrollments.ToPagedList(EnrollmentPageNumber,5);
     }
     return View(viewModel);
    }
