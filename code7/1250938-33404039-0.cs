    var querySubjectQuestions = (from questions in db.questions
                                 join studentspersonalinformation in db.studentspersonalinformation on questions.DNI equals studentspersonalinformation.DNI
                                 where questions.IDSubject == IDSubject && questions.status == 1
                                 select new
                                 {
                                     IDQuestion = questions.IDQuestion,
                                     Title = questions.title,
                                     Date = questions.date,
                                     studentName = studentspersonalinformation.name,
                                     studentSurname = studentspersonalinformation.surname,
                                     noAnswers = (from answer in db.answers 
                                                 where answer.IDQuestion == questions.IDQuestion)
                                                 select answer).Count()
                                  }).OrderByDescending(c => c.Date);
