    public class CodesController : Controller
    {
        public ActionResult GetListJson()
        {
            var testlist = new List<string> { "AA", "BB", "CC" };
            return this.Json(testlist, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetListView()
        {
            var testlist = new List<string> { "AA", "BB", "CC" };
            return this.View(testlist);
        }
    }
