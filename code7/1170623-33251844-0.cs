     var data = _patientaskquestionRepository.Table.Include(x=>x.DoctorSendAnswer).Join(_patientRepository.Table, a => a.PatientId, d => d.Id, (a, d) => new { d = d, a = a }).Where(x => x.a.DoctorId == doctorid);
             if(!string.IsNullOrEmpty(status))
              data=data.Where(x=>x.a.Status==status);
              var result = data.Select(x => new {x= x.a,y=x.d }).ToList();
              var dt = result.Select(x => new PatientAskQuestionModel()
              {
                  PatientId = x.x.PatientId.Value,
                  AskQuestion = x.x.AskQuestion,
                  Id = x.x.Id,
                  DoctorId = x.x.DoctorId,
                  FileAttachment1Url = x.x.FileAttachment1,
                  DocName = x.y.FirstName + " " + x.y.LastName,
                  CreatedDate = x.x.CreatedDate.Value,
                  doctorSendAnswerModel = x.x.DoctorSendAnswer.Select(t => new DoctorSendAnswerModel { Answer = t.Answer }).ToList()
              }).ToList();
            
              return dt;
