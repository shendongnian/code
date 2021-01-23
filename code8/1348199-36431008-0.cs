    public class ValidationExceptionHandlerErrorAttribute : HandleErrorAttribute
        {
            public override void OnException(ExceptionContext filterContext)
            {
                //only handle ValidationExceptions
                if ((filterContext.Exception as ValidationException) != null)
                {
                    var result = new ContentResult();
                    //Add errors to Model State so they are handled auto-magically
                    foreach (var validationsfailures in (filterContext.Exception as ValidationException).Errors)
                    {
                        filterContext.Controller.ViewData.ModelState.AddModelError(validationsfailures.PropertyName,validationsfailures.ErrorMessage);
                    }
                    //convert to json and return to ajax request
                    string content = JsonConvert.SerializeObject(filterContext.Controller.ViewData.ModelState,
                        new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                    result.Content = content;
                    result.ContentType = "application/json";
                    filterContext.HttpContext.Response.StatusCode = 400;
                    filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                    filterContext.Result = result;
                    filterContext.ExceptionHandled = true;
                }
            }
        }
