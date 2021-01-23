    public class ProductController: Controller
    {
        private IDataRetreiever DataRetriever {get; set;}
      
        public ProductController(IDataRetriever dataRetriever) //this is called Constructor Injection
        {
            DataRetriever = dataRetriever;
        }
    
        public ActionResult List()
        {
            var data = DataRetriever.GetData();
            return View(data);
        }
    }
