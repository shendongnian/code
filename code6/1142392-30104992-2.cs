    public void LoadStudents()
    {
      using (var db2 = new MyDbContext()
      {
        //Lambda Linq
        var studentList = new List<Student>();
        studentList = db2.Students
                         .Include(s => s.StudentCourses)
                         .OrderBy (s => s.StudentId)
                         .ToList();
        
        //Comprehension Linq 
        var compList = new List<Student>();
        compList = (from s in dbs.Students.Include(r => r.StudentCourses)
                   OrderBy s.StudentId
                   Select s).ToList();
      }
    }
