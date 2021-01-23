    public class SampleController : Controller
    {
        [BreadCrumb]
        public ActionResult GetProduct(int id)
        {
            var model = db.GetProduct(id);
            BreadCrumb.SetLabel("Product " + model.ProductName);
            return View(model);
        }
    }
