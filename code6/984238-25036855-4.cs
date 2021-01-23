    public class NewValueController : Controller
    {
        public ActionResult New()
        {
            return PartialView(new NewValueViewModel());
        }
    
        [HttpPost]
        public ActionResult New(NewValueViewModel model)
        {
            var newValue = string.Format("{0} - {1}", model.Foo, model.Bar);
            return Json(new { newValue = newValue });
        }
    }
