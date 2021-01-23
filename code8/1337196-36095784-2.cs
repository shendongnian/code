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
    
    		public List<ControllerContext> ToList(HomeController context)
    		{
    
    			return new List<ControllerContext> { context.ControllerContext };
    		}
    	}
    
    	public interface IControllerContextClonable
    	{
    		List<ControllerContext> ToList(HomeController context);
    
    	}
    }
