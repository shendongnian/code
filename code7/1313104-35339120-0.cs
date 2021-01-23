    public class ExceptionAttribute : IExceptionFilter
    {
        /// <summary>
        /// Handles any exception
        /// </summary>
        /// <param name="filterContext">The current context</param>
        public void OnException(ExceptionContext filterContext)
        {
            // If our exception has been handled, exit the function
            if (filterContext.ExceptionHandled)
                return;
            // Set our base status code
            var statusCode = (int)HttpStatusCode.BadRequest;
            // If our exception is an http exception
            if (filterContext.Exception is HttpException)
            {
                // Cast our exception as an HttpException
                var exception = (HttpException)filterContext.Exception;
                // Get our real status code
                statusCode = exception.GetHttpCode();
            }
            // Set our context result
            var result = CreateActionResult(filterContext, statusCode);
            // Set our handled property to true
            filterContext.Result = result;
            filterContext.ExceptionHandled = true;
        }
        /// <summary>
        /// Creats an action result from the status code
        /// </summary>
        /// <param name="filterContext">The current context</param>
        /// <param name="statusCode">The status code of the error</param>
        /// <returns></returns>
        protected virtual ActionResult CreateActionResult(ExceptionContext filterContext, int statusCode)
        {
            // Create our context
            var context = new ControllerContext(filterContext.RequestContext, filterContext.Controller);
            var statusCodeName = ((HttpStatusCode)statusCode).ToString();
            // Create our route
            var controller = (string)filterContext.RouteData.Values["controller"];
            var action = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controller, action);
            // Create our result
            var view = SelectFirstView(context, string.Format("~/Views/Error/{0}.cshtml", statusCodeName), "~/Views/Error/Index.cshtml", statusCodeName);
            var result = new ViewResult { ViewName = view, ViewData = new ViewDataDictionary<IError>(this.Factorize(model)) };
            // Return our result
            return result;
        }
        /// <summary>
        /// Factorizes the HandleErrorInfo
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        protected virtual IError Factorize(HandleErrorInfo error)
        {
            // Get the error
            var model = new Error
            {
                Message = "There was an unhandled exception."
            };
            // If we have an error
            if (error != null)
            {
                // Get our exception
                var exception = error.Exception;
                // If we are dealing with an ApiException
                if (exception is ApiException || exception is HttpException)
                {
                    // Get our JSON
                    var json = JObject.Parse(exception.Message);
                    var message = json["exceptionMessage"] != null ? json["exceptionMessage"] : json["message"];
                    // If we have a message
                    if (message != null)
                    {
                        // Update our model message
                        model.Message = message.ToString();
                    }
                }
                else
                {
                    // Update our message
                    model.Message = exception.Message;
                }
            }
            // Return our response
            return model;
        }
        /// <summary>
        /// Gets the first view name that matches the supplied names
        /// </summary>
        /// <param name="context">The current context</param>
        /// <param name="viewNames">A list of view names</param>
        /// <returns></returns>
        protected string SelectFirstView(ControllerContext context, params string[] viewNames)
        {
            return viewNames.First(view => ViewExists(context, view));
        }
        /// <summary>
        /// Checks to see if a view exists
        /// </summary>
        /// <param name="context">The current context</param>
        /// <param name="name">The name of the view to check</param>
        /// <returns></returns>
        protected bool ViewExists(ControllerContext context, string name)
        {
            var result = ViewEngines.Engines.FindView(context, name, null);
            return result.View != null;
        }
    }
