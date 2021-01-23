    public void LoadStudents()
    {
      //Lambda Linq
      var lambdaList = db2.Students
                          .Include(s => s.StudentCourses.Select(sc => sc.Course))
                          .OrderBy(s => s.StudentId)
                          .ToList();
     //Comprehension Linq
     var compList = (from student in db2.Students.Include(s => s.StudentCourse.Select(sc => sc.Course)
                     OrderBy student.StudentId
                     Select student).ToList(); 
    }
