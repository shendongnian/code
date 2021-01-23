    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new PagedList<string>(
                new List<string> { "test1", "test2"}.AsEnumerable(), 1, 2 ));
        }
    }
    @model PagedList.IPagedList<string>
    @(Model.ConvertToJson())
