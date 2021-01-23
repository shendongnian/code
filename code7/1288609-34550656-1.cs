    public class WebGridSampleController
    {
        private StudentRepository _data;
 
        public WebGridSampleController()
        {
            _data = new StudentRepository();
        }
        public ActionResult Show1(StudentVm oSVm)
        {
            var students = _data.GetStudents(oSVm.page, oSVm.pageSize, oSVm.sort, oSVm.sortDir);
            oSVm.Students = students.ToList();
            return View(oSVm);
        }
    }
    public class StudentRepository
    {
        public IEnumerable<Student> GetStudents(int page, int pageSize, string sort, string sortDir)
        {
            // Put the code that you have in StudentVM.GetAllStudents here
        }
    }
