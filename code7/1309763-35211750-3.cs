    //Both Doctors and Receptionist have access to Patient controller.
    [UserRoleAuthorize(Roles="Doctors, Receptionist")]
    public class PatientController : Controller
    {
         //Both Doctors and Receptionist have access to Schedule an appointment for patients.
         public ActionResult Schedule()
         {
                return View();
         }
         //Only Doctors have access to Treat patients.
         [UserRoleAuthorize(Roles="Doctors")]
         public ActionResult TreatPatient()
         {
                return View();
         }
    }
