    public class YourView
    {
        public ActionResult Index()
        {
            string firstName = "Stephen";
            TempData["FirstName"] = firstName;
            return View();
        }
        public void ButtonClicked()
        {
            string firstName = (string)TempData["FirstName"];
        }
    }
