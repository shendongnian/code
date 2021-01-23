    public class ExceptionHandlerAttribute : HandleErrorAttribute
    {
        private static readonly string[] DefinedException = { "SessionTimeOutException", "UnauthorizedAccessException" };
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
                return;
    
            var validationContainer = new ValidationContainer();
            filterContext.ExceptionHandled = true;
            var exceptionName = filterContext.Exception.GetType().Name;
            string exceptionMessage;
            if (DefinedException.Contains(exceptionName))
            {
                exceptionMessage = filterContext.Exception.Message;
            }
            else
            {
                exceptionMessage = "We intentionally allowed to not catch exception to track the root causes. Please note down the steps and include following details in the bug.</br>"
                                   + "</br></br>Exception Message: " + filterContext.Exception;
            }
            validationContainer.AddMessage(MessageType.Error, exceptionMessage);
    
            filterContext.Result = new JsonResult
            {
                Data = validationContainer,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
