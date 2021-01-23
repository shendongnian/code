    public IActionResult Create()
    {
        // I hard coded the student id and the courses here.
        // you may replace it with real data.
        var vm = new StudentCourseVM { StudentId = 12 }; 
        //Assuming we are assigning courses to the student with id 12
        vm.SelectedCourses = new List<SelectedCourse>()
        {
            new SelectedCourse {Id = 1, Name = "CSS"},
            new SelectedCourse {Id = 2, Name = "Swift"},
            new SelectedCourse {Id = 3, Name = "IOS"},
            new SelectedCourse {Id = 4, Name = "Java"}
        };
        return View(vm);
    }
