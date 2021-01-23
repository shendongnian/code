    public class SetTempDataModelStateAttribute : ActionFilterAttribute
        {
            public override async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
            {
                await base.OnActionExecutionAsync(filterContext, next);
    
                var controller = filterContext.Controller as Controller;
                var modelState = controller?.ViewData.ModelState;
                if (modelState != null)
                {
                    var listError = modelState.ToDictionary(m => m.Key, m => m.Value.Errors
                        .Select(s => s.ErrorMessage)
                        .FirstOrDefault(s => s != null));
                    var listErrorJson = await Task.Run(() => JsonConvert.SerializeObject(listError));
                    controller.TempData["ModelState"] = listErrorJson;
                }
                await next();
            }
        }
    public class RestoreModelStateFromTempDataAttribute : ActionFilterAttribute
        {
            public override async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
            {
                await base.OnActionExecutionAsync(filterContext, next);
    
                var controller = filterContext.Controller as Controller;
                var tempData = controller?.TempData?.Keys;
                if (controller != null && tempData != null)
                {
                    if (tempData.Contains("ModelState"))
                    {
                        var modelStateString = controller.TempData["ModelState"].ToString();
                        var listError = await Task.Run(() => 
                            JsonConvert.DeserializeObject<Dictionary<string, string>>(modelStateString));
                        var modelState = new ModelStateDictionary();
                        foreach (var item in listError)
                        {
                            modelState.AddModelError(item.Key, item.Value ?? "");
                        }
    
                        controller.ViewData.ModelState.Merge(modelState);
                    }
                }
                await next();
            }
        }
