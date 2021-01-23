    var semesters = (from cou in db.Courses
        join sem in db.Semesters on cou.SemesterID equals sem.ID
        where cou.FacultyID == id 
        select new { SemesterID = sem.ID, SemesterText = sem.Semester };
    List<SemestersModel> semesterList = semesters
        .Distinct()
        .Select(x => new SemestersModel {
            SemesterID = x.SemesterID, 
            SemesterText = x.SemesterText })
        .ToList(); 
