    public class CodesController : Controller
    {
        public ActionResult GetListView()
        {
            var json = /*somehow you got your [{"hr":"AA", "PS":"BB"}, ... ] JSON */;
            var list = JsonConvert.DeserializeObject<List<MyItem>>(json);
            var text = string.Join(",", list.Select(x => string.Format("[{0},{1}]", x.hr, x.PS)));
            return this.Content(text);
        }
    }
