    public class NewsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            Post firstPost = db.Posts.FirstOrDefault();
            return View(firstPost);
        }
        public PartialViewResult GetComments(string postId)
        {
            Guid post = Guid.Parse(postId);
            List<Comment> comments = db.Comments.Where(c => c.PostId == post).ToList();
            return PartialView("~/Views/News/_Comments.cshtml", comments);
        }
        [HttpPost]
        public JsonResult AddComment(string postId,string content)
        {
            Guid post = Guid.Parse(postId);
            var comment = new Comment
            {
                id = Guid.NewGuid(),
                PostId = post,
                content = content
            };
            db.Comments.Add(comment);
            db.SaveChanges();
            return Json(new {Created = true }, JsonRequestBehavior.AllowGet);
        }
    }
