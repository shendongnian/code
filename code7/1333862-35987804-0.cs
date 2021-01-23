    public class SetTempDataModelStateAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                base.OnActionExecuted(filterContext);
    
                var controller = filterContext.Controller as Controller;
                if (controller != null)
                {
                    var modelState = controller.ViewData.ModelState;
                    if (modelState != null)
                    {
                        var dictionary = new KeyValuePair<string, ModelStateEntry>[modelState.Count];
                        modelState.CopyTo(dictionary, 0);
                        var listError = dictionary.ToDictionary(m => m.Key, m => m.Value.Errors.Select(s => s.ErrorMessage).FirstOrDefault(s => s != null));
                        controller.TempData["ModelState"] = JsonConvert.SerializeObject(listError);
                    }
                }
            }
        }
    
        public class RestoreModelStateFromTempDataAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);
    
                var controller = filterContext.Controller as Controller;
                var tempData = controller?.TempData?.Keys;
                if (controller != null && tempData != null)
                {
                    if (tempData.Contains("ModelState"))
                    {
                        var modelStateString = controller.TempData["ModelState"].ToString();
                        var listError = JsonConvert.DeserializeObject<Dictionary<string, string>>(modelStateString);
                        var modelState = new ModelStateDictionary();
                        foreach (var item in listError)
                        {
                            modelState.AddModelError(item.Key, item.Value ?? "");
                        }
    
                        controller.ViewData.ModelState.Merge(modelState);
                    }
                }
            }
        }
