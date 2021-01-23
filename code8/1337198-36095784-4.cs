    using System.Collections.Generic;
    using System.Web.Mvc;
    
    namespace WebApplication1.Controllers
    {
        public class HomeController : Controller, IControllerContextClonable
        {
            public ActionResult Index()
            {
                var controller = (HomeController) this.MemberwiseClone();
                var list = ToList(controller.ControllerContext);
    
                return View();
            }
    
            public List<ControllerContext> ToList(ControllerContext context)
            {
    
                return new List<ControllerContext> { context};
            }
        }  
    
        public interface IControllerContextClonable
        {
            List<ControllerContext> ToList(ControllerContext context);
    
        }
    }
