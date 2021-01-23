    public class HomeController : Controller
    {
        [...]
        public virtual ActionResult GetExample()
        {
            [...]
            var result = ...;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public virtual ActionResult Update(MyModel model)
        {
            [...]
            var result = model
            return Json(result);
        }
        [...]
    }
