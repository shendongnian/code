    public class HomeController : Controller
    {
        private readonly IToastNotification _toastNotification;
        public HomeController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }
        ...
    }
