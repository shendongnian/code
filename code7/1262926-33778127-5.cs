    public class DashboardController : Controller
    {
        private readonly IHardwareService _hardwareService;
        public DashboardController(IHardwareService hardwareService)
        {
            _hardwareService = hardwareService;
        }
    }
