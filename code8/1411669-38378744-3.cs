    public class CodesController : Controller
    {
        public ActionResult GetList()
        {
            var testlist = new List<string> { "AA", "BB", "CC" };
            return this.Json(testlist, JsonRequestBehavior.AllowGet);
        }
    }
