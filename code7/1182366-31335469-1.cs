    private IEnumerable<examAverage> GetGrades()
    {
    var values = (from grades in db.Grades
              group grades by grades.ExamID into avgGrade
              select new 
                  {
                      ExamID = avgGrade.Key,
                      Grade= (int)avgGrade.Average(x => x.Grade)
                  });
    foreach (var value in values) yield return new examAverage{
           ExamID = value.ExamId,
           Grade = value.Grade
        };
    }
