    foreach (Course course in filter.Courses) {
        if (course != null) {
            var cId = course.CourseID;       
            filteredStudents = filteredStudents
                .Where(s => s.Courses.Select(c => c.CourseID).Contains(cId))
                    .Select(s => s);
        }
    }
