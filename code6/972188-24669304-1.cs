    [RoutePrefix("projects")]
    public class UsergroupController : ApiController
    {
        [Route("{projectId}/usergroups"), HttpGet]
        public IHttpActionResult Get()
        {
            // Url: /projects/123/usergroups
            // Response: null
            object value = null;
            var webApiRouteData = HttpContext.Current.Request.RequestContext.RouteData.GetWebApiRoutes();
            value = webApiRouteData["projectId"];
            return Ok(value);
        }
    }
