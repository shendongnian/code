    public class HandleExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.Exception != null)
            {
                Guid guid = Guid.NewGuid();
                string guidStr = guid.ToString();
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        success = false, 
                        error = "Error al procesar su solicitud, por favor comuniquese con un administrador con el siguiente codigo: " + guidStr,
                        StackTrace = filterContext.Exception.StackTrace
                    }
                };
                filterContext.ExceptionHandled = true;
                var properties = new Dictionary<string, string> { { "Error GUID", guidStr } };
                var telemetry = new TelemetryClient();
                // Send the exception telemetry:
                telemetry.TrackException(filterContext.Exception, properties);
                // Added this line
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true            
            }
            else
            {
                base.OnException(filterContext);
            }
        }
    }
