    public class HomePageController : Umbraco.Web.Mvc.RenderMvcController
    {
        // GET: HomePage
        public override ActionResult Index(RenderModel model)
        {
            //Check country and redirect
            string country = RegionInfo.CurrentRegion.DisplayName;
            if (country == "France")
            {
                Response.Redirect("http://fr.mySite.org");
            }
            return base.Index(model);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
