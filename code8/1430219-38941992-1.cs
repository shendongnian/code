    public class ArticlesController : Controller
        {
            List<Article> articles = new List<Article>()
            {
                new Article{ ID=1,Title="Article 1",Body="This is article 1..."},
                new Article{ ID=2,Title="Article 2",Body="This is article 2..."},
                new Article{ ID=3,Title="Article 3",Body="This is article 3..."}
            };
    
            public ActionResult Index()
            {
                Article article = articles.First();
                return View(article);
            }
    
            public JsonResult GoToPost(int id,string type)
            {
                int originalId = id;
                int newId = type == "Previous" ? --id : ++id;
                Article article = articles.FirstOrDefault(e=>e.ID == newId);
                if(article == null)
                    article = articles.FirstOrDefault(e => e.ID == originalId);
    
                return Json(article, JsonRequestBehavior.AllowGet);
            }
        }
