    private List<CourseSelection> GetCourses()
    {
        //Hard coded for demo. Replace with entries from db
        return new List<CourseSelection>()
        {
            new CourseSelection {CourseId = 1, CourseName = "CS"},
            new CourseSelection {CourseId = 2, CourseName = "MT"}
        };
    }
            
    public ActionResult Index()
    {
        var vm = new CreateCustomerVM();
        vm.Courses = GetCourses();
        return View(vm);
    }
