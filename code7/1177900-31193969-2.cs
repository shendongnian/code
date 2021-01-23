     var ret = (from e in db.Enrollments
                       join c in db.Courses on e.CourseID equals c.CourseID
                       where e.StudentID == StudentID && e.CourseID == CourseID
                       select new
                       {
                           courseStartDate = c.CourseStartDate,
                           courseEndDate = c.CourseEndDate,
                           projectName = e.Project.ProjectTitle,
                           graduated = e.Graduated
    
                       }).ToList()
                       .Select(a => new StudentCourseDetails() {
                           courseDates = a.courseStartDate.ToString() + " " + a.courseEndDate.ToString(),
                           projectName = a.projectName,
                           graduated = a.graduated
                       }).FirstOrDefault();
