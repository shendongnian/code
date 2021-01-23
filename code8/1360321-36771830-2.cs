    public class DataController : Controller
    {
        private readonly IProvideeDataFeedData _eDataFeedDataProvider;
        public DataController(IProvideeDataFeedData eDataFeedDataProvider)
        {
            _eDataFeedDataProvider = eDataFeedDataProvider;
        }
        public ActionResult Index()
        {
            var values = _eDataFeedDataProvider.GetAllDayAheadLoad().actualValueData
                .Where(a => a.name == "Western Region")
                .ToDictionary(a => a.timestamp, a => a.value);
            var model = new IndexModel
            {
                Region = "Western Region",
                Message = values.Any(v => v.Value > 50000) ? "Heavy Load" : "Everything is cool",
                Values = values
            };
            return View(model);
        }
    }
