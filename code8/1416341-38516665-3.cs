    public class MyController
    {
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Index()
        {
            return View();
        {
    }
