    using System.Data.Entity;
    ...
    using (var studentUow = new StudentUow()) {
        Student s = studentUow.Student.Queryable().Include(x => x.Courses).First(x => x.StudentId == studentId);
        foreach (int courseId in courses) {
            Course c = studentUow.Course.Queryable().First(x => x.CourseId == courseId);
            s.Courses.Add(c);
            c.Students.Add(s);
            studentUow.Course.Update(c);
        }
        studentUow.Student.Update(s);
        studentUow.Commit();
    }
