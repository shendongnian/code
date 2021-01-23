    var results = (from student in context.Students
                   group student by 1 into grp
                   select new
                   {
                       ClassSize = grp.Count(),
                       PassingStudents = grp.Count(s => s.FinalGrade != "F")
                   }).Single();
    var passingPercent = 100.0 * (double)results.PassingStudents / (double)results.ClassSize;
