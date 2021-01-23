    public void LoadStudents()
    {
      using (var db2 = new MyDbContext()
      {
        var studentList = new List<Student>();
        studentList = db2.Students
                         .Include(s => s.StudentCourses)
                         .OrderBy (s => s.StudentId)
                         .ToList();
      }
    }
