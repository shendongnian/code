    public class ProductController: Controller
    {
        private IDataRetreiever DataRetriever {get; set;}
      
        public ProductController(IDataRetriever dataRetriever)
        {
            DataRetriever = dataRetriever;
        }
    
        public ActionResult List()
        {
            var data = DataRetriever.GetData();
            return View(data);
        }
    }
