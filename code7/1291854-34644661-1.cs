    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ServiceController[] Services;
            Services = ServiceController.GetServices();
            ServicesViewModel servicesViewModel = new ServicesViewModel();
            ServisModel servisler = new ServisModel();
            List<ServicesViewModel> list = new List<ServicesViewModel>();
            foreach (ServiceController svc in Services)
            {                
                servicesViewModel.ServiceName = svc.ServiceName;
                servicesViewModel.ServiceDisplayName = svc.DisplayName;
                servicesViewModel.ServiceStatus = svc.Status;
                list.Add(servicesViewModel);
            }            
            return View(new ServicesList(list));            
        }
        public class ServicesList : IEnumerable
        {
            private List<ServicesViewModel> liste = new List<ServicesViewModel>();
            
            public ServicesList(List<ServicesViewModel> l) {
                liste = l;
            }
            
            public IEnumerator GetEnumerator()
            {
                return new MyEnumerator(liste);
            }
        }
