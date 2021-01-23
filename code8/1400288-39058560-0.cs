    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            context.Result = new ContentResult
            {
                Content = $"Error: {exception.Message}",
                ContentType = "test/plain",
                // change to whatever status code you want to send out
                StatusCode = (int?)HttpStatusCode.BadRequest 
            }
        }
    }
