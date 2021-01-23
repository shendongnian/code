    IQueryable<Student> filteredStudents = context.Students;
    foreach (Course course in filter.Courses) {
        if (course != null) {  
            int CourseID = course.CourseID;            
            filteredStudents = filteredStudents
                .Where(s => s.Courses.Select(c => c.CourseID).Contains(CourseID));
        }
    }
    List<Student> studentList = filteredStudents.ToList<Student>();
