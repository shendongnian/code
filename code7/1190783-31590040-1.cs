    public class JobsController : Controller
    {
    
      public ActionResult Index()
      {
        var model = new Job();
        var tasks = db.JobTypes.Select(c => new SelectListItem {Value =   c.JobTypeID.ToString(), Text = c.JobDescription});
        model.JobTypeItems = tasks;
        return View(model);
      }
    }
