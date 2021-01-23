     public class APIErrorHandler : IExceptionHandler
     {
         public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
         {
             var customObject = new CustomObject
                 {
                     Message = new { Message = context.Exception.Message }, 
                     Status = ... // whatever,
                     Data = ... // whatever
                 };
            //Necessary to return Json
            var jsonType = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;    
    
            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, customObject, jsonType);
    
            context.Result = new ResponseMessageResult(response);
    
            return Task.FromResult(0);
        }
    }
