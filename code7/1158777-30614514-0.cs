        public class ViewRExceptionFilterAttribute : ExceptionFilterAttribute
        {
        // Global context message for the modifying the context response in case of exception
        private string globalHttpContextMessage;
    
        /// <summary>
        ///     Overriding the OnException method as part of the Filter, which would detect the type of Action and would
        ///     accordingly modify the Http
        ///     context response
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(HttpActionExecutedContext context)
        {
            // Dictionary with Type and Action for various Type actions, current method is called by various types
            Dictionary<Type, Action> dictionaryExceptionTypeAction = new Dictionary<Type, Action>();
    
            // Add an action for a given exception type
            dictionaryExceptionTypeAction.Add(typeof (ViewRClientException), ViewRClientExceptionAction(context.Exception));            
            dictionaryExceptionTypeAction.Add(typeof (Exception), SystemExceptionAction(context.Exception));
    
            // Execute an Action for a given exception type
            if (context.Exception is ViewRClientException)
                dictionaryExceptionTypeAction[typeof (ViewRClientException)]();
           else
                dictionaryExceptionTypeAction[typeof (Exception)]();
    
            // Reset the Context Response using global string which is set in the Exception specific action
            context.Response = new HttpResponseMessage
            {
                Content = new StringContent(globalHttpContextMessage)
            };
        }
    
        /// <summary>
        ///     Action method for the ViewRClientException, creates the Exception Message, which is Json serialized
        /// </summary>
        /// <returns></returns>
        private Action ViewRClientExceptionAction(Exception viewRException)
        {
            return (() =>
            {
                LogException(viewRException);
    
                ViewRClientException currentException = viewRException as ViewRClientException;
    
                ExceptionMessageUI exceptionMessageUI = new ExceptionMessageUI();
    
                exceptionMessageUI.ErrorType = currentException.ErrorTypeDetail;
    
                exceptionMessageUI.ErrorDetailList = new List<ErrorDetail>();
    
                foreach (ClientError clientError in currentException.ClientErrorEntity)
                {
                    ErrorDetail errorDetail = new ErrorDetail();
    
                    errorDetail.ErrorCode = clientError.ErrorCode;
    
                    errorDetail.ErrorMessage = clientError.ErrorMessage;
    
                    exceptionMessageUI.ErrorDetailList.Add(errorDetail);
                }
    
                globalHttpContextMessage = JsonConvert.SerializeObject(exceptionMessageUI, Formatting.Indented);
            });
        }
