    namespace Deepak_MVC_2.Controllers
    {
        public class StudentController : Controller
        {
            public ActionResult GetStudents()
            {
                StudentModelManager smm = new StudentModelManager();
                List<StudentModel> lsm = smm.GetAllStudentInfo();
                ActionResult ar = View(lsm);
                return ar;
            }
        }
    }
