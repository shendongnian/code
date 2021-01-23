    class UserPagesController : Controller {
        [ValidateInput(false)]
        public ActionResult Save(UserPage page) {
            var db = new DbContext(); // Your db context..
            db.Save(userPage);
            var path = string.Format("~/Views/UserPages/Page{1}.cshml", page.Id);
            path = Server.MapPath(path);
            File.WrileAllText(path, page.Html);
            return ...;
        }
        [HttpGet]
        public ActionResult View(int id) {
            var db = new DbContext();
            var page = db.Pages.FirstOrDefault(p => p.Id == id);
            if( page != null) {
                var path = string.Format("~/Views/UserPages/Page{1}.cshml", page.Id);
                return View(path);
            } else {
                return HttpNotFound();
            }
        }   
    }
