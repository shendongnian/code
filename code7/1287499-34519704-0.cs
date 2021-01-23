    public class ErrorController : ApiController
    {
        [HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead, HttpOptions, AcceptVerbs("PATCH")]
        public HttpResponseMessage HandleErrors()
        {
            HttpResponseMessage message = new HttpResponseMessage();
            message.Content = new StringContent("<html><body><div>This is a custom message that will be displayed to the user in HTML format</div></body></html>");
            message.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/html");
            message.StatusCode = HttpStatusCode.InternalServerError;
            return message;
        }
    }
