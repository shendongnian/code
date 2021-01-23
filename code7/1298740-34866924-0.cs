       class Test
        {
            public ActionResult Index(int? courseId, string grade, int? statusId)
            {
                var query = from s in db.Students
                            join e in db.Enrollments on s.ID equals e.ID
                            join c in db.Courses on e.CourseID equals c.ID
                            orderby e.Grade.HasValue descending, e.Grade, s.StatusID
                            select QueryResults(courseId, grade, statusId, s, e, c);
                
            }
            public ViewModels.ReportView QueryResults(int? courseId, string grade, int? statusId, Student student, Enrollments enrollment, Cource course)
            {
                if ((courseId != null) && (courseId != course))
                {
                    return null;
                }
                if ((!string.IsNullOrEmpty(grade)) && (grade != enrollment.Grade))
                {
                    return null;
                }
                if ((statusId != null) && (statusId != student.StatusID))
                {
                    return null;
                }
                return new ViewModels.ReportView
                {
                    ID = student.ID,
                    Name = student.FirstName + " " + student.LastName,
                    Course = course.Title,
                    Grade = enrollment.Grade,
                    GraduationDate = student.GraduationDate,
                    Status = student.Status.Title
                });
            }
        }
