    public class CodesController : Controller
    {
        public ActionResult GetListJson()
        {
            var list = new List<string> { "AA", "BB", "CC" };
            return this.Json(list , JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetListText()
        {
            var list = new List<string> { "AA", "BB", "CC" };
            return this.View(string.Join(",", list));
        }
        public ActionResult GetListView()
        {
            var list = new List<string> { "AA", "BB", "CC" };
            return this.View(list);
        }
    }
