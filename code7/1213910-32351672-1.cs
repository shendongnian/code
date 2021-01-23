    public class TreeviewController : Controller
    {
        public JsonResult GetRoot()
        {
            List<JsTreeModel> items = GetTree();
            return new JsonResult { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetChildren(string id)
        {
            List<JsTreeModel> items = GetTree(id);
            return new JsonResult { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        static List<JsTreeModel> GetTree()
        {
            var items = new List<JsTreeModel>();
            // set items in here
            return items;
        }
        static List<JsTreeModel> GetTree(string id)
        {
            var items = new List<JsTreeModel>();
            // set items in here
        
            return items;
        }
    }
