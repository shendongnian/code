    public class HomeController : Controller
    {
         private DatabaseContext db = new DatabaseContext();
         public ActionResult RandomPosts(int categoryId)
         {
              var randomPosts = db.Posts.Where(x => x.CategoryId == categoryId)
                                        .OrderBy(r => Guid.NewGuid()).Take(3);
              return View(randomPosts);
         }
    }
