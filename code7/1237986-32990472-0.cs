    public class BasicController {
        public JsonResult IncrementViews(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var element = DBHelper.GetElements(db, this.GetType()).Single(x => x.Id == id);
                element.UniquePlayCounts++;
                db.SaveChanges();
                return Json(new { UniquePlayCounts = song.UniquePlayCounts }, JsonRequestBehavior.AllowGet);
            }
        }
    }
