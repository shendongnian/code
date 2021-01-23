        public StudentAdapterModel SaveStudent(StudentAdapterModel studentAdapterModel)
        {
            try
            {
                Student student = null;
                if (studentAdapterModel.EventId == 0)
                {
                    student = new Student();
                    student = Mapper.Map<StudentAdapterModel, Student>(studentAdapterModel);
                    studentRepository.Add(student);
                }
                else
                {
                    //student = studentRepository.GetById(studentAdapterModel.EventId);
                    student = studentRepository.Get(e => e.EventId == studentAdapterModel.EventId);
                    try
                    {
                        student = Mapper.Map<StudentAdapterModel, Student>(studentAdapterModel);
                    }
                    catch (Exception ex2)
                    {
                        string errMess = ex2.ToString().Trim();
                    }
                    auctionEventRepository.Update(auctionEvent);
                  
                }
                unitOfWork.Commit();
                studentAdapterModel.EventId = student.EventId;
                return studentAdapterModel;
            }
            catch (Exception ex)
            {
                string errMess = ex.ToString().Trim();
            }
            return null;
        }
