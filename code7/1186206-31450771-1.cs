       public ActionResult EditStudentCourse()
        {
            StudentCourseSchoolAndCampusViewModel _StudentCourseModel = new StudentCourseSchoolAndCampusViewModel();
           _StudentCourseModel = _studentProfileServices.GetCourseByStudentID(6);
            
            return PartialView("EditStudentCourse_Partial", _StudentCourseModel);
        }
