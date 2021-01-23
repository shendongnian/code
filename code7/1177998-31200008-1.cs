    public class MyController : Controller
    {
        /* ... your code ... */
    
        [ChildActionOnly]
        public ActionResult Sliders()
        {
            var model = new List<Models.Slider>();
    
            model = Database.Session.Query<Slider>().Where(s => s.DeletedAt == null).OrderBy(x=>x.SortOrder).ToList();
    
            return PartialView("your-view-name", model);
        }
    }
