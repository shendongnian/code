    public abstract class BaseController : Controller
    {
        protected string ConnectionString = WebConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
    
        protected void LogException(Exception ex)
        {
            var path = HttpContext.Server.MapPath("~/App_Data");
            ExceptionLog.Create(Ex, path);
        }    
    }
    public class DashboardController : BaseController
    {
        public ActionResult Index()
        {
            try
            {
                string conn = base.ConnectionString;
                //codes
            }
            catch (Exception ex)
            {
                base.LogException(ex);
            }
            return View("AdminDashboard");
        }
    }
