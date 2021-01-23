    namespace Student.Controllers
    {
        // Avoid Authorize Attribute when in Debug mode.
    #if !DEBUG
        [Authorize]
    #endif
        public class StudentController : AppController
        {
        }
    }
