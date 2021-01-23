    public class ErrorController : ApiController
    {
        public HttpResponseMessage Handle404()
        {
            const string notFoundString = "The requested resource could not be found";
            var responseMessage = Request.CreateResponse(HttpStatusCode.NotFound, new ResponseModel<object>
            {
                Success = false,
                ResultMessage = notFoundString
            });
            responseMessage.ReasonPhrase = notFoundString;
            return responseMessage;
        }
    }
