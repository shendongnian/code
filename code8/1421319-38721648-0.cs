    public class ElmahLogger : ActionFilterAttribute
    {
       public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
          {
             if ((actionExecutedContext.Response != null) && !actionExecutedContext.Response.IsSuccessStatusCode)
             {
                try
                {
                    var messages = (System.Web.Http.HttpError)((System.Net.Http.ObjectContent<System.Web.Http.HttpError>)actionExecutedContext.Response.Content).Value;
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var keyValuePair in messages)
                        stringBuilder.AppendLine(keyValuePair.Value.ToString());
    
                    Elmah.ErrorSignal.FromCurrentContext().Raise(new HttpException((int)actionExecutedContext.Response.StatusCode, stringBuilder.ToString()));
                }
                catch (Exception ex)
                    Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception("Error in ElmahLoggerFilter - OnActionExecuted: " + ex.ToString()));
            }
        }
    }
