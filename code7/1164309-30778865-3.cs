    public class CompanyController : Controller
    {
         private readonly IUnitOfWorkFactory uowFactory;
         private readonly IRepositoryFactory repoFactory;
    
         public CompanyController (
                 IUnitOfWorkFactory uowFactory,
                 IRepositoryFactory repoFactory)
         {
              uowFactory = uowFactory;
              repoFactory = repoFactory;
         }
    
         public ActionResult Index()
         {
             using(var uow = uowFactory.Create()) 
             {
                 var companyRepo = repoFactory.Create<Company>(uow);
    
                 return View(companyRepo.AllBySomePredicate(x => x.CompanyJoined == DateTime.Now.AddMonths(-2)));
             }
         }
    }
