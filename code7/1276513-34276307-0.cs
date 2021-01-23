    public class ControllerBase : ApiController
    {
        protected string ClassName = "ControllerBase::";
    
        public override System.Threading.Tasks.Task<HttpResponseMessage> ExecuteAsync(System.Web.Http.Controllers.HttpControllerContext controllerContext, System.Threading.CancellationToken cancellationToken)
        {
            try
            {
                System.Threading.Tasks.Task<HttpResponseMessage> TaskList = base.ExecuteAsync(controllerContext, cancellationToken);
    
                if (TaskList.Exception != null && TaskList.Exception.GetBaseException() != null)
                {
                    JSONErrorResponse AsyncError = new JSONErrorResponse();
                    AsyncError.ExceptionMessage = TaskList.Exception.GetBaseException().Message;
                    AsyncError.ErrorMessage = string.Format("Unknown error {0} ExecuteAsync {1}", ClassName ,controllerContext.Request.RequestUri.AbsolutePath);
                    AsyncError.HttpErrorCode = HttpStatusCode.BadRequest;
    
                    HttpResponseMessage ErrorResponse = controllerContext.Request.CreateResponse(AsyncError.HttpErrorCode, AsyncError);
    
                    return System.Threading.Tasks.Task.Run<HttpResponseMessage>(() => ErrorResponse);
                }
                return TaskList;
            }
            catch (Exception Error)
            {
                JSONErrorResponse BadParameters = new JSONErrorResponse();
                BadParameters.ExceptionMessage = Error.Message;
                BadParameters.ErrorMessage = string.Format("Method [{0}], or URL [{1}] not found, verify your request", controllerContext.Request.Method.Method, controllerContext.Request.RequestUri.AbsolutePath);
                BadParameters.HttpErrorCode = HttpStatusCode.NotFound;
                HttpResponseMessage ErrorResponse = controllerContext.Request.CreateResponse(BadParameters.HttpErrorCode, BadParameters);
    
                return System.Threading.Tasks.Task.Run<HttpResponseMessage>(() => ErrorResponse);
            }
        }
    }
    
    public class JSONErrorResponse
    {
        //Possible message from exception
        public string ExceptionMessage { get; set; }
        //Possible custom error message
        public string ErrorMessage { get; set; }
        //Http error code
        public HttpStatusCode HttpErrorCode { get; set; }
    }
