    //Global exception handler that will be used to catch any error
    public class MyExceptionHandler : ExceptionHandler
        {
            private class ErrorInformation
            {
                public string Message { get; set; }
                public DateTime ErrorDate { get; set; }            
            }
     
            public override void Handle(ExceptionHandlerContext context)
            {
                context.Result = new ResponseMessageResult(context.Request.CreateResponse(HttpStatusCode.InternalServerError, 
                  new ErrorInformation { Message="An unexpected error occured. Please try again later.", ErrorDate=DateTime.UtcNow }));
            }
       }
