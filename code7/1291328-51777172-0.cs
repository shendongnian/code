     using (var context = new SchoolContext())
     {
          var student = context.Students
                                  .Where(s => s.FirstName == "Bill")
                                 .FirstOrDefault<Student>();
                        context.Entry(student).Reference(s => s.StudentAddress).Load(); 
                                // loads StudentAddress
                        context.Entry(student).Collection(s => s.StudentCourses).Load(); 
                                // loads Courses collection      
                      }
