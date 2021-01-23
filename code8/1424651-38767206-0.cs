    class Title
    {
        // ctor that generates stub data 
        public Title()
        {
            Func<string> f = () => new string(Guid.NewGuid().ToString().Take(5).ToArray());
            A = "A : " + f();
            B = "B : " + f();
            C = "C : " + f();
            D = "D : " + f();
        }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            var data = new List<Title>()
            {
                new Title(), new Title(),
                new Title(), new Title()
            };
            // list of properties to display for user
            var fieldsSelectedByUser = new[] { "A", "C" };
            // here we obtain a list of propertyinfos from Title class, that user requested
            var propsInfo = typeof(Title).GetProperties().Where(p => fieldsSelectedByUser.Any(z => z == p.Name)).ToList();
            // query that returns list of properties in List<List<object>> format
            var result = data.Select(t => propsInfo.Select(pi => pi.GetValue(t, null)).ToList()).ToList();
            return View(result);
        }
        ...
    }
  
