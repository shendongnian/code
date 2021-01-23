        public class PassthroughExceptionHandler : IExceptionHandler
        {
            public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
            {
                // don't just throw the exception; that will ruin the stack trace
                var info = ExceptionDispatchInfo.Capture(context.Exception);
                info.Throw();
            }
        }
        
