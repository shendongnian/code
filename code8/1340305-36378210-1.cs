        public class HomeCustomDataBinder : DefaultModelBinder
        {
            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                if (bindingContext.ModelType == typeof(HomePageModels))
                {
                    HttpRequestBase request = controllerContext.HttpContext.Request;
    
                    string title = request.Form.Get("Title");
                    string day = request.Form.Get("Day");
                    string month = request.Form.Get("Month");
                    string year = request.Form.Get("Year");
    
                    return new HomePageModels
                    {
                        Title = title,
                        Date = day + "/" + month + "/" + year
                    };
    
                    //// call the default model binder this new binding context
                    //return base.BindModel(controllerContext, newBindingContext);
                }
                else
                {
                    return base.BindModel(controllerContext, bindingContext);
                }
            }
    
        } 
