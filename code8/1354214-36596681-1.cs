    public class MyController : MyBaseController
    {
        public ActionResult Index()
        {
            var data = MyService.GetData(UserID);
            return View(data);
        }
    }
