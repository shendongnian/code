    public ItemsController : Controller {
        private readonly IItemsService _service;
        public ItemsController(IItemsService service) {
            _service = service;
        }
    
        public ActionResult Index(){
            return View("Index", _service.GetItemsForUser(HttpContext.Current.User.Identity.Name));
        } 
