        //student = studentRepository.GetById(studentAdapterModel.EventId);
                student = studentRepository.Get(e => e.EventId == studentAdapterModel.EventId);
                try
                {
                    //student = Mapper.Map<StudentAdapterModel, Student>(studentAdapterModel);
                    student.Name = StudentAdapterModel.Name;
                }
                catch (Exception ex2)
                {
                    string errMess = ex2.ToString().Trim();
                }
