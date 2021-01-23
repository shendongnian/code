    var courses = resultset.GroupBy(
        row => new { row.CourseId, row.CourseCode },
        row => new Student
                {
                    StudentId = row.StudentId,
                    StudentName = row.StudentName,
                    StudentNo = row.StudentNo,
                    StudentSurname = row.StudentSurname,
                },
        (key, valueList) => new Course
                    {
                        CourseId = key.CourseId,
                        CourseCode = key.CourseCode,
                        EnrolledStudents = valueList.ToList()
                    }
    ).ToList();
