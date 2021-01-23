    public class JobsController : Controller
    {
      var tasks = db.JobTypes.Select(c => new SelectListItem {Value = c.JobTypeID.ToString(), Text = c.JobDescription});
      ViewBag.JobTypeAllNames = tasks;
      return View();
    }
