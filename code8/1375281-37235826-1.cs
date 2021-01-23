    var expandedGrades =
                    from grade in DBContext.Grades
                    select new
                    {
                        Name = grade.Student.Name,
                        Gender = grade.Student.Gender,
                        Nationality = grade.Student.Nationality,
                        Year = grade.Year,
                        Grade = grade.Grade
                    };
