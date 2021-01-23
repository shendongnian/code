        public List<StudentCourseSchoolAndCampusViewModel> GetCourseByStudentID(int _studentID)
        {
            try
            {
                using (var _uow = new StudentProfile_UnitOfWork())
                {
                    var _record = (from _course in _uow.Course_Repository.GetAll()
                        join _school in _uow.School_Repository.GetAll() on _course.SchoolID equals _school.SchoolID
                        join _campus in _uow.Campus_Repository.GetAll() on _course.CampusID equals _campus.CampusID
                        where _course.StudentID == _studentID
                        select new { _course, _school, _campus }).ToList();
    
    
                    var studentsVM = _record.Select(s=> new StudentCourseSchoolAndCampusViewModel(){_courseModel = s._course, _schoolModel = s._school, _campusModel = s._campus});
    
                    return studentsVM;
                }
            }
            catch { return null; }
        } 
