    using System.Web.Mvc;
    using AuthDemo.Models;
    
    namespace AuthDemo.Controllers {
        public class MemberController : Controller {
            //
            // GET: /Member/
    
            [Authorize]
            public ActionResult Index() {
                UserModel user = (UserModel)this.Session["user"];
    
                return View("Index", user);
            }
    
        }
    }
