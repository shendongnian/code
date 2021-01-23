    using Umbraco.Web.Mvc;
    public class CPDPlanSurfaceController : SurfaceController
    {
        [HttpGet]
        public ActionResult removeObjective(int planId)
        {
            return RedirectToCurrentUmbracoPage();
        }
    }
