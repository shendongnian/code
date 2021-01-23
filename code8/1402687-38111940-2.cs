     public class HomeController : Controller
    {
        public ActionResult YIndex()
        {
            using (BreazEntities7 db = new BreazEntities7())
            {
                var allRecs = db.Examples;
                foreach (var rec in allRecs)
                {
                    rec.SomeValue = "TEST";
                }
                db.SaveChanges();
            }
            return View();
    }
