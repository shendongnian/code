    IQueryable<Student> filteredStudents = context.Students;
    foreach (Course c in filter.Courses) {
        Course course = c; 
        if (course != null) {             
            filteredStudents = filteredStudents
                .Where(s => s.Courses.Select(c => c.CourseID).Contains(course.CourseID));
        }
    }
    List<Student> studentList = filteredStudents.ToList<Student>();
