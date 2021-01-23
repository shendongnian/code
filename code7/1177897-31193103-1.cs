    public JsonResult FillCourseInfo(int StudentID, int CourseID)
    {
         var ret = (from e in db.Enrollments 
                   join c in db.Courses on e.CourseID equals c.CourseID
                   where e.StudentID == StudentID && e.CourseID == CourseID
                   select new StudentCourseDetails
                   {
                       courseDates = c.CourseStartDate.ToString() + " " + c.CourseEndDate.ToString(),
                       projectName = e.Project.ProjectTitle,
                       graduated = e.Graduated
    
                   });
        return Json(ret);
    }
