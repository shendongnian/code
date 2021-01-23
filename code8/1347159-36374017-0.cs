    uow.Exams().GetAll().Select(e => new {
        StudentName = e.Student.Name,
        ExamTitle = e.Title,
        ExamDate = e.ExamDate,
        LastExamDate = e.Student.Exams.Max(e => e.ExamDate)
    })
