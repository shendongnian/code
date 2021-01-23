    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new NiceInternalServerExceptionResponse(
                "The current operation could not be completed sucessfully.",
                HttpStatusCode.InternalServerError);
        }
    }
