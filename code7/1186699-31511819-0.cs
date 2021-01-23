        public StudentDetailedProfileViewModel GetStudentDetailedProfileByStudentID(int _studentID)
        {
            try
            {
                 using (var _uow = new StudentProfile_UnitOfWork())
                {
                     StudentDetailedProfileViewModel StudentProfileObject = new StudentDetailedProfileViewModel();
                    var _profile = (from _student in _uow.Student_Repository.GetAll()
                                    join _contactDetail in _uow.ContactDetail_Repository.GetAll() on _student.StudentID equals _contactDetail.StudentID
                                    join _studentCourse in _uow.Course_Repository.GetAll() on _student.StudentID equals _studentCourse.StudentID
                                    join _school in _uow.School_Repository.GetAll() on _studentCourse.SchoolID equals _school.SchoolID
                                    join _campus in _uow.Campus_Repository.GetAll() on _studentCourse.CampusID equals _campus.CampusID
                                    where _student.StudentID == _studentID
                                    select new StudentDetailedProfileViewModel { _studentModel = _student, _contactDetailModel = _contactDetail, _courseModel = _studentCourse,_schoolModel = _school, _campusModel = _campus}).FirstOrDefault();
                    _profile._emergencyContactModel = (from _emergencyContact in _uow.EmergencyContact_Repository.GetAll()
                                                      where _emergencyContact.StudentID == _studentID
                                                      select _emergencyContact).ToList();
                 
                    return _profile;                
                }
            }//
            catch { return null; }
        }
