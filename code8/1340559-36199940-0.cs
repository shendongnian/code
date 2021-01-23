    public IActionResult IWillNotBeCalled()
    {
        return new UnauthorizedWithMessageResult("MY SQL ERROR");            
    }
    public class UnauthorizedWithMessageResult : IActionResult
    {
        private readonly string _message;
        public UnauthorizedWithMessageResult(string message)
        {
            _message = message;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            // you need to do this before setting the body content
            context.HttpContext.Response.StatusCode = 403;
            var myByteArray = Encoding.UTF8.GetBytes(_message);
            await context.HttpContext.Response.Body.WriteAsync(myByteArray, 0, myByteArray.Length);
            await context.HttpContext.Response.Body.FlushAsync();
        }
    }
