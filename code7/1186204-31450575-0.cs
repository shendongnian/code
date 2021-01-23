    //...
    var _record = (from _course in _uow.Course_Repository.GetAll()
                    join _school in _uow.School_Repository.GetAll() on _course.SchoolID equals _school.SchoolID
                    join _campus in _uow.Campus_Repository.GetAll() on _course.CampusID equals _campus.CampusID
                    where _course.StudentID == _studentID
                    // Here is the problem, you have to specify the type.
                    select new StudentCourseSchoolAndCampusViewModel { 
                               Course = _course, 
                               School = _school, 
                               Campus = _campus }).ToList();
