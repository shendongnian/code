    public class ErrorController : ApiController
        {
            [HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead, HttpOptions, AcceptVerbs("PATCH")]
            public HttpResponseMessage Handle404()
            {
                HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.NotFound, Logger.ConditionWarning("Invalid API Request - 404 Not Found"));
                return response;
            }
        }
