    [RoutePrefix("Home")]
    public ActionResult HomeController : Controller
    {
      [Route("{storeName}")]
      public ActionResult ProcessStore(string storeName)
      {
       // to do : Return something
      }
      public ActionResult Index()
      {
       // to do : Return something
      }
    }
    [RoutePrefix("Payment")]
    public ActionResult PaymentController : Controller
    {
      [Route("{storeName}")]
      public ActionResult ProcessStore(string storeName)
      {
       // to do : Return something
      }
    }
