    public class ResidentialBuildingController : Controller
    {
        private BIRDSResidentialEntities db = new BIRDSResidentialEntities();
    
        // GET: ResidentialBuilding
        public ActionResult Index()
        {
            BuildingViewModel model = new BuildingViewModel();
            model.ResidentialBuildings  = db.ResidentialBuildings.ToList();
            model.ResidentialLocations  = db.ResidentialLocations.ToList();
            
            return View(model);
        }
    }
