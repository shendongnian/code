    namespace MvcApplication1.Controllers
    {
        public class HomeController : Controller
        {
            //
            // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "ProductName, ProductId")]Product product) 
        {
            SampleContext db = new SampleContext();
            if (ModelState.IsValid) 
            {
                product.UserId = (int)Membership.GetUser().ProviderUserKey;
                db.Products.Add(product); 
                db.SaveChanges(); 
                return RedirectToAction("Index"); 
            } 
            return View(product); 
        }
        public ActionResult List()
        {
            SampleContext db = new SampleContext();
            IEnumerable<Product> products = db.Products.ToList();
            return View(products);
        }
    }
    }
