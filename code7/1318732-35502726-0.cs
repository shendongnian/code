         public class ExceptionHandlerAttribute : HandleErrorAttribute
            {
                private static readonly string[] DefinedException = { "SessionTimeOutException", "UnauthorizedAccessException" };
        
                /// <summary>
                ///   Overriden method to handle exception
                /// </summary>
                /// <param name="filterContext"> </param>
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
                                         //  + "</br></br>Stack Trace: " + filterContext.Exception.StackTrace;
                    }
    
    // Add the Error Message to Validation Container
                    validationContainer.AddMessage(MessageType.Error, exceptionMessage);
    
                    //TODO: write Exception to Log file
    
                    filterContext.Result = new JsonResult
                    {
                        Data = validationContainer,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
        
                    var context = HttpContext.Current;
                    //ErrorLog.GetDefault(context).Log(new Error(filterContext.Exception, context));
                }
            }
