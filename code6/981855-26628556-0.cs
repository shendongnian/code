    public class HomeController
    {
        // Use the ActivateAttribute to inject services into your controller
        [Activate]
        public ViewDataDictionary ViewData { get; set; }
    
        public ActionResult Index()
        {
            return new ViewResult() { ViewData = ViewData };
        }
    }
