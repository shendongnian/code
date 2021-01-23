    public class ProductsController : Controller
    {
        private ProductContext db = new ProductContext();
        private void LoadCreateViewBagData()
        {
            string domain = Request.Url.Host;
            int clientid = (from a in db.Client where a.Domain == domain select a.ID).First();
            int maxID = db.Product.Where(c => c.ClientID == clientid).Max(c => (int?)c.ProductID) ?? 0;
            ViewBag.MaxID = maxID + 1;
            IEnumerable<SelectListItem> categories = db.Category.Where(d => d.ClientID == clientid).Select(b => new SelectListItem { Text = b.Name, Value = b.CategoryID.ToString() });
            ViewData["categories"] = categories;
            ViewBag.ClientID = clientid;
        }
        // GET: Admin/Products
        public ActionResult Index()
        {
            string domain = Request.Url.Host;
            int clientid = (from a in db.Client where a.Domain == domain select a.ID).First();
            LoadCreateViewBagData();
            return View(db.Product.Include("Category").Where(c => c.ClientID == clientid).OrderByDescending(a => a.ProductID).ToList());
        }
