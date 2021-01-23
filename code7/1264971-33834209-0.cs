    public class HomeController : Umbraco.Web.Mvc.RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            //Do some stuff here, then return the base method
            return base.Index(model);
        }
    
    }
