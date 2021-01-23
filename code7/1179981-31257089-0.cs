    public class PlansController : AsyncController
    {
        [Route("tasks/{id}")]
        public ActionResult Index(string id)
        {
            if(id == null)
            {
                 return View("ViewName");
            }
            else
            {
                 //Query DB and get model for the view
                 return View("ViewName", Model);
            }
        }
    }
