    IQueryable<Student> filteredStudents = context.Students;
    foreach (Course course in filter.Courses) {
        if (course != null) {             
            filteredStudents = filteredStudents
                .Where(s => s.Courses.Select(c => c.CourseID).Contains(course.CourseID))
                .ToList(); //should work, because a List is still an IEnumerable
        }
    }
    List<Student> studentList = filteredStudents.ToList<Student>();
