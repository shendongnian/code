    public abstract class WebApiControllerBase : ApiController {
        [Route("{*actionName}")]
        [AcceptVerbs("GET", "POST", "PUT", "DELETE")]
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        public virtual HttpResponseMessage HandleUnknownAction(string actionName) {
            var status = HttpStatusCode.NotFound;
            var message = "[Message placeholder]";
            var content = new { message = message, status = status};
            return Request.CreateResponse(status, content);
        }
    }
