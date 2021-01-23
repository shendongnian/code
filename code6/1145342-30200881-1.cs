    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            var merchant1 = new MerchantModel
            {
                AppId = 1,
                Name = "Bob"
            };
            var merchant2 = new MerchantModel
            {
                AppId = 2,
                Name = "Ted"
            };
            var merchant3 = new MerchantModel
            {
                AppId = 3,
                Name = "Alice"
            };
            List<MerchantModel> list = new List<MerchantModel>();
            list.Add(merchant1);
            list.Add(merchant2);
            list.Add(merchant3);
            var model = new MerchantViewModel
            {
                Merchants = list
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(MerchantViewModel model)
        {
            return View(model);
        }
    }
