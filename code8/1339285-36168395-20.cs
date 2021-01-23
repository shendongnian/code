    using System;    
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    public class SystemController : Controller
    {
        //
        // GET: /System/Status301/
        public ActionResult Status301()
        {
            var routeValues = this.Request.RequestContext.RouteData.DataTokens["routeValues"];
            var url = this.GetAbsoluteUrl(routeValues);
            Response.CacheControl = "no-cache";
            Response.StatusCode = (int)HttpStatusCode.MovedPermanently;
            Response.RedirectLocation = url;
            ViewBag.DestinationUrl = url;
            return View();
        }
        private string GetAbsoluteUrl(object routeValues)
        {
            var urlBuilder = new UriBuilder(Request.Url.AbsoluteUri)
            {
                Path = Url.RouteUrl(routeValues)
            };
            var encodedAbsoluteUrl = urlBuilder.Uri.ToString();
            return HttpUtility.UrlDecode(encodedAbsoluteUrl);
        }
    }
