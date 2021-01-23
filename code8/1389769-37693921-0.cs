    public class Category
    {
        public string CategoryName { get; set; }
        public string ImageSrc { get; set; }
    }
    
    public class HomeController : Controller
    {
        public ActionResult HomePage()
        {
            return View();
        }
    
        [HttpGet]
        public JsonResult GetJsonData()
        {
            var c1 = new Category { CategoryName = "Dairy", ImageSrc = "http://gilowveld.sites.caxton.co.za/wp-content/uploads/sites/97/2016/03/Dairy-products.jpg" };
            var c2 = new Category { CategoryName = "Fruits", ImageSrc = "http://science-all.com/images/wallpapers/fruits-images/fruits-images-4.jpg" };
    
            List<Category> categories = new List<Category> { c1, c2 };
    
            return Json(categories, JsonRequestBehavior.AllowGet);
        }
    }
