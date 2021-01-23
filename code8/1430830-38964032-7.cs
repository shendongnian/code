    [HttpPost]
    public IActionResult Create(StudentCourseVM model)
    {
        var studentId = model.StudentId; 
        foreach (var modelSelectedCourse in model.SelectedCourses)
        {
            if (modelSelectedCourse.IsSelected)
            {
                //this one is selected. Save to db
            }
        }
        // to do : Return something
    }
