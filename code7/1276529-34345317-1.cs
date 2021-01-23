        public class ExceptionHandlingFilter : ExceptionFilterAttribute
        {
            public override void OnException(HttpActionExecutedContext context)
            {
                // do stuff with the exception
                
                var request = context.Request;
                ResponseModel respMod = null;
                
                // Example: if debug constant is not defined, mask exception, otherwise create normal object with message, inner exception and stacktrace
                #if !DEBUG
                respMod = new ResponseModel(context.Exception, context.Exception.Message, true);
                #else
                respMod = new ResponseModel(context.Exception);
                #endif
                context.Response = request.CreateResponse(HttpStatusCode.InternalServerError, respMod);
            }
        }
