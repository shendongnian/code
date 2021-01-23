    using System.Collections.Generic;
    using System.Web.Mvc;
    
    namespace WebApplication1.Controllers
    {
        public class HomeController : Controller, IControllerContextClonable
        {
            public ActionResult Index()
            {
                var controller = (HomeController) this.MemberwiseClone();
                var list = ToList(controller);
    
                return View();
            }
    
            public List<IControllerContextClonable> ToList(IControllerContextClonable context)
            {
    
                return new List<IControllerContextClonable> { context};
            }
        }    
    
        public interface IControllerContextClonable
        {
            List<IControllerContextClonable> ToList(IControllerContextClonable context);    
        }
    }
