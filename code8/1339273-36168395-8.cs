    using System.Net;
    using System.Web.Mvc;
    public class SystemController : Controller
    {
        //
        // GET: /System/Status301/?url=(some url)
        public ActionResult Status301(string url)
        {
            // Never cache a 301 redirect
            Response.CacheControl = "no-cache";
            Response.StatusCode = (int)HttpStatusCode.MovedPermanently;
            Response.RedirectLocation = url;
            ViewBag.DestinationUrl = url;
            return View();
        }
    }
