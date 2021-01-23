    public class HomeController : Controller
    {
        public ActionResult DropExample()
        {
            var fruits = new List<SelectListItem>();
            fruits.Add(new SelectListItem { Text = "Orange", Value = "1" });
            fruits.Add(new SelectListItem { Text = "Banana", Value = "2" });
            fruits.Add(new SelectListItem { Text = "Grapes", Value = "3" });
            ViewBag.Fruits = fruits;
            return View();
        }
        public JsonResult GetJsonData(string value,string text)
        {
            System.Diagnostics.Debugger.Break();
            string message = String.Format("You have selcted - {0}({1}).This is from the server...",text,value);
            return Json(new {Message = message }, JsonRequestBehavior.AllowGet);
        }
    }
