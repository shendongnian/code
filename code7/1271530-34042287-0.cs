    public static IEnumerable<Tbl_Students> GetAllStudents()
    {
        StudentDBEntities dataContext = new StudentDBEntities();
        var query = (from student in dataContext.Tbl_Students
                     join subject in dataContext.Tbl_Subjects on student.Roll_Number equals subject.Roll_Number
                     select new 
                     {
                         Roll_Number = student.Roll_Number,
                         FirstName = student.FirstName,
                         LastName = student.LastName,
                         Class = student.Class,
                         Gender = student.Gender,
                         Science = subject.Science,
                         Social = subject.Social,
                         Mathematics = subject.Mathematics,
                         Total = subject.Total
                     }).ToList().Select(s => new Tbl_Students
                     {
                         Roll_Number = s.Roll_Number,
                         FirstName = s.FirstName,
                         LastName = s.LastName,
                         Class = s.Class,
                         Gender = s.Gender,
                         Tbl_Subjects = new Tbl_Subjects ()
                         {
                              Science = s.Science,
                              Social = s.Social,
                              Mathematics = s.Mathematics,
                              Total = s.Total
                               Roll_Number = s.Roll_Number
                         };
                     });
        return query;
    }
