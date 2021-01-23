    if (schedules.Count() > 1)
    {
        var scheduleCourseIds = schedules.Select(sch => sch.Course.Id).ToList();
    
        doublestudents = (from s in ctx.Students
                            let studentCourseIds = s.Courses.Select(c => c.Id)
                            where !scheduleCourseIds.Except(studentCourseIds).Any()
                            select s).ToList();
    
        Console.WriteLine(doublestudents.Count);
    }
