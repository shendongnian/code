    using (var context = new SchoolContext())
    {
        var student = context.Students
                        .Where(s => s.FirstName == "Bill")
                        .FirstOrDefault<Student>();
    
        context.Entry(student)
                 .Collection(s => s.StudentCourses)
                   .Query()
                .Where(sc => sc.CourseName == "Maths")
                .FirstOrDefault();
    }     
