     ctx.Departments.AddRange(departments);
        ctx.SaveChanges();
        ctx.Courses.AddRange(courses);
        ctx.SaveChanges();
        ctx.Specializtions.AddRange(specializations);
        ctx.SaveChanges();
