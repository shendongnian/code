    using (IUnitOfWork unitOfWork = new UnitOfWork())
            {
             StudentListViewModel SVm = new StudentListViewModel();
            SVm.SetUpParams(oSVm);
            SVm.Students =  unitOfWork.studentRepository.GetStudents(SVm.StartIndex, SVm.EndIndex, SVm.sort, oSVm.sortdir).ToList();
            }
