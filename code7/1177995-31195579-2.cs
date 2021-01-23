    public class MyController : Controller
    {
        /* ... your code ... */
    
        [ChildActionOnly]
        public ActionResult Sliders()
        {
            var model = new Models.Slider();
    
            /* ... populate model ... */
    
            return PartialView("your-view-name", model);
        }
    }
