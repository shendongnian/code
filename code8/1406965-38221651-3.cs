    var semesters = from cou in db.Courses
                    join sem in db.Semesters 
                    on cou.SemesterID equals sem.ID
                    where cou.FacultyID == id 
                    select new { SemesterID = sem.ID, SemesterText = sem.Semester };
    List<SemestersModel> uniqueSemesterList = semesters
        .Distinct()   
        .Select(x => new SemestersModel {
            SemesterID = x.SemesterID, 
            SemesterText = x.SemesterText })
        .ToList(); // due to deferred execution only now the query above will be executed together with Distinct
