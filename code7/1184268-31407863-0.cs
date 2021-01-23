    public class HandleExceptionAttribute : HandleErrorAttribute
    {
        private bool IsAjax(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }
            // if the request is AJAX return JSON else view.
            if (IsAjax(filterContext))
            {
                Guid guid = Guid.NewGuid();
                string guidStr = guid.ToString();
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                filterContext.HttpContext.Response.StatusDescription = "Error al procesar su solicitud, por favor comuniquese con un administrador con el siguiente codigo: " + guidStr;
                filterContext.ExceptionHandled = true;
                var properties = new Dictionary<string, string> { { "Error GUID", guidStr } };
                var telemetry = new TelemetryClient();
                // Send the exception telemetry:
                telemetry.TrackException(filterContext.Exception, properties);
            }
            else
            {
                //Normal Exception
                //So let it handle by its default ways.
                base.OnException(filterContext);
            }
        }
    }
