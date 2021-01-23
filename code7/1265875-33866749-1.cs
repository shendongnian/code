    // get the number of questions by subject
    var result =
        (from s in db1.SubjectTables
         select new
         { 
             s.SubjectID,
             s.SubjectName,
             Count = db1.QuestionsTables.Count(q => q.SubjectID == s.SubjectID)
         }).ToList();
