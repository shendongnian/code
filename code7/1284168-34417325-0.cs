    public class NewItemDeliveryController : Controller
    {
    // GET: NewItemDelivery
    public ActionResult Index()
    {
        var model = new NewItemDeliveryModel(){*Set your Dictionnary here*};
        return View("NewItemDelivery",model);
    }
    }
