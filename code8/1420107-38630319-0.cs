    public static IQueryable LoadTeacher(int teacherID)
    {
        using (var context = new SchoolContext())
        {
            var retVal = from teacher in context.Teachers
                         where teacher.ID == teacherID
                         select new {
                               Teacher = teacher,
                               StudentNames = from student in teacher.Students
                                              select student.Name
                               }
             return retVal;
        }
    }
