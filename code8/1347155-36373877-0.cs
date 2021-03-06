    var list = (from s in uow.Students.GetAll()
                join e in uow.Exams.GetAll() on s.Id equals e.StudentId
                select new ExamViewModel
                {
                    StudentName = s.Name,
                    ExamTitle = e.Title,
                    ExamDate = e.ExamDate,
                    LastExamDate = e.Last(s.Id == e.StudentId)
                });
