    var values = (from grades in db.Grades
              group grades by grades.ExamID into avgGrade
              select new 
                  {
                      ExamID = avgGrade.Key,
                      Grade= (int)avgGrade.Average(x => x.Grade)
                  });
    foreach (var value in values) 
    {
        var grade = new examAverage{
           ExamID = value.ExamId,
           Grade = value.Grade
        };
        // save grade here
    }
