    public class PropertyController : Controller
    {
        private readonly ICountyService _countyService;
        public PropertyController(ICountyService countyService)
            : base()
        {
            _countyService = countyService;
        }
        [HttpGet]
        public ActionResult NewProperty()
        {
            using (UnitOfWorkManager.NewUnitOfWork())
            {
                ListAllCountiesViewModel listAllCountyViewModel = new ListAllCountiesViewModel()
                {
                    ListAllCounty = _countyService.ListOfCounties().ToList()
                };
                PropertyViewModel viewModel = new PropertyViewModel()
                {
                    _listAllCountyViewModel = listAllCountyViewModel,
                    _countyViewModel = new CountyViewModel(),
                };
                return View(viewModel);
            }
         }
     }
