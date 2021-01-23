     public class MBUser : IModelBinder
        {
    
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                HttpContextBase httpContextBase = controllerContext.RequestContext.HttpContext;
                UrlValidation urlValidation = new UrlValidation();
                //Binding posted values to UrlValidation type
                urlValidation.Expirydate = DateTime.ParseExact(
                    httpContextBase.Request["UrlValidation.Expirydate"].ToString(),
                    "d/M/yyyy", CultureInfo.InvariantCulture).ToString("G");
                urlValidation.ProjectTypeID = Convert.ToInt16(httpContextBase.Request["ProjectType"]);
                urlValidation.Url = httpContextBase.Request["UrlValidation.Url"].ToString();
                string datetime = DateTime.Now.ToString("G");
                urlValidation.CreateDate = datetime;
                // returning UrlValidation type
                return urlValidation; 
            }
        }
