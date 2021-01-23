    public class ManageController
    {
        readonly IManageSessionContext _manageSessionContext;
    
        public ManageController(IManageSessionContext manageSessionContext)
        {
            _manageSessionContext = manageSessionContext;
    
            //some operations..
            _manageSessionContext.Clear();
        }
    
        public ActionResult Index()
        {
            _manageSessionContext.DoSomeWorkWithManagedContext();
    
            _manageSessionContext.Clear();
    
            return View();
        }
    
    }
