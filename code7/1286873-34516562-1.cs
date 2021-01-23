    using System.Web;
    using System.Web.Mvc;
    namespace LapisRealmv2.Controllers
    {
        public class WelcomeController : Controller
        {
            public ActionResult Index()
            {
                HttpCookie cookie = new HttpCookie("Visited");
                // The cookie will expire when the browser is closed.
                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                return View();
            }
        }
    }
