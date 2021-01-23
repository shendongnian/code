    var students = db.Students.Select(s => {}).ToList();
    var studentIds = students.Select(s=>s.Id).ToArray();
    var subjects = db.Subjects.Where(s=>studentIds.Contains(s.StudentId))
        .ToArray()
        .GroupBy(s=>s.StudentId)
        .ToDictionary(g=>g.Key, g=>g.ToList());
    //Populate subjects for each student
    students.ForEach(s=>
    {
        s.subjects = subjects.ContainsKey(s.Id)?subjects[s.Id]:new List<Subject>();
    });
