    public class HomeController : Controller
    {
        private IEditDataRepository _editDataRepository;
        //Dependency Injection using Unity.MVC5 NyGet Packages
        public HomeController(IEditDataRepository editDataRepository)
        {
            _editDataRepository = editDataRepository;
        }
        // GET: 
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Field1,Field2")] FormViewModel model)
        {
            if (ModelState.IsValid)
            {
                _editDataRepository.Edit(model);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                throw new HttpException(400, "ModelState Invalid");
            }
        }
    }
