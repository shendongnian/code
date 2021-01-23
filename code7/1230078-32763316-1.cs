    public class ExceptionJsonResponse : HttpResponseMessage
    {
        public ExceptionJsonResponse(Exception exception, IClientExceptionFormatter formatter)
        {
            ...
            _exception = exception;
            _formatter = formatter;
            Content = CreateContent();
            StatusCode = HttpStatusCode.InternalServerError;
        }
        private HttpContent CreateContent()
        {
            HttpContent content = new StringContent(_formatter.GetJson(_exception));
            content.Headers.ContentType = new MediaTypeHeaderValue(Common.ContentType.ApplicationJson);
            return content;
        }
        ...
    }
