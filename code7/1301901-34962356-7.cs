    public class HomeController : Controller
    {
        public ActionResult GetEmailForm()
        {
            return View();
        }
        public ActionResult SubmitEmail(EmailViewModel model)
        {
            var result = SendEamil(model);
            return View();
        }
        private bool SendEamil(EmailViewModel model)
        {
            // Use model and send email with your code.
            return true;
        }
    }
