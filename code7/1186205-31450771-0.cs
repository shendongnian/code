     public partial class StudentProfileServices
    {
        #region Get Student Course By StudentID
        public StudentCourseSchoolAndCampusViewModel GetCourseByStudentID(int _studentID)
        {
            try
            {
                using (var _uow = new StudentProfile_UnitOfWork())
                {
                    var _record = (from _course in _uow.Course_Repository.GetAll()
                                  join _school in _uow.School_Repository.GetAll() on _course.SchoolID equals _school.SchoolID
                                  join _campus in _uow.Campus_Repository.GetAll() on _course.CampusID equals _campus.CampusID
                                  where _course.StudentID == _studentID
                                  select new StudentCourseSchoolAndCampusViewModel  {_courseModel= _course, _schoolModel = _school, _campusModel = _campus }).FirstOrDefault();
                    return _record;
                }
            }
            catch { return null; }
        }
