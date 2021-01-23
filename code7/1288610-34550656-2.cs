    public class StudentController
    {
        private StudentRepository _data;
 
        public StudentController()
        {
            _data = new StudentRepository();
        }
        public ActionResult List(StudentListViewModel viewModel)
        {
            var students = _data.GetStudents(viewModel.Page, viewModel.PageSize, viewModel.Sort, viewModel.SortDirection);
            viewModel.Students = students.ToList();
            return View(viewModel);
        }
    }
    public class StudentRepository
    {
        public IEnumerable<Student> GetStudents(int page, int pageSize, string sort, string sortDir)
        {
            // Put the code that you have in StudentVM.GetAllStudents here
        }
    }
    
