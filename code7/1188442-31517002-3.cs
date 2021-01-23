    public class TestService : ITestService{
       private IReposotory repo;
    
       public TestService(IReposotory repo){
         this.repo = repo;
       }
       
       public TestModel GetModel()
       { 
          return new TestModel()
    {
        Categories = _repository.Categories.Select(c => new CategoryModel
        {
            Id = c.Id,
            Name = c.Name
        })
    };       
       }
    }
    
    public class HomeController : Controller
    {
        private readonly ITestService _service;
    
        public HomeController (ITestService service){
           _service = service;
       }
    
        public ActionResult Index()
        {        
            return View(_service.GetModel());
        }
    
        [HttpPost]
        public ActionResult Index(TestModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Succes");
            }
            return View(model);
        }
    
        public ActionResult Succes()
        {
            return View();
        }
    }
