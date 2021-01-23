    (from cou in db.Courses
        join sem in db.Semesters on cou.SemesterID equals sem.ID
        where cou.FacultyID == id 
        select sem)
        .GroupBy(sem => sem.Semester)
        .Select(g => g.First())
        .Select(sem => new SemestersModel {
            SemesterID = sem.ID,
            SemesterText = sem.Semester 
        })
        .ToList();
