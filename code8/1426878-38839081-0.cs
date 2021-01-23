    public class ParticipantController : Controller
    {
        public ActionResult Index()
        {
            return Content("Reques for partiicpant index page if needed");
        }
        public ActionResult create(string studentProgram)
        {
            return Content("Partiicpant create for "+studentProgram);
        }
    }
    public class CourseController : Controller
    {
        public ActionResult Index()
        {
            return Content("Course:");
        }
    }
