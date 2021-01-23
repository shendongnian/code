    var query = context.Teachers.Select(teacher => new 
    {
        teacher.Id,
        teacher.Name,
        Students = teacher.Students.Select(student => new
        {
            student.Id,
            student.Name,
        }
    }
