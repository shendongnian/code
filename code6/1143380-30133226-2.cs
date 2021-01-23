    public class CustomerController : Controller 
    {
       public ActionResult Index() 
       {
           return View();
       }
    
       [HttpPost]
       public ActionResult UpdateOrder()
       {
          // some code
          return Json(new { success = true, message = "Order updated successfully" }, JsonRequestBehavior.AllowGet);
       }
    }
