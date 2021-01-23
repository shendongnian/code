    var expandedGrades =
        DBContext.Grades.Select(grade =>
        new
        {
            Name = grade.Student.Name,
            Gender = grade.Student.Gender,
            Nationality = grade.Student.Nationality,
            Year = grade.Year,
            Grade = grade.Grade
        });
