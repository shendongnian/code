    public class TestController: Controller
    {
       public ActionResult ProcessResponse(Guid id)
       {
            //
            //lookup & process the record using the id...
            //
            return View("ThankYou");  // <-- will display the "ThankYou.cshtml" view
       }
    }
