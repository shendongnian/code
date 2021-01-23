    IQueryable<Student> filteredStudents = context.Students;
    var courses = filter.Courses.Select(c => c.CourseID);
    var studentList = filteredStudents
           .Where(s => s.Courses.Select(c => c.CourseID)
                           .Intersect(courses)
                           .Any()
           ).ToList();
