    public class LongBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext.HttpContext.Request.Form[bindingContext.ModelName] != null)
            {
                var decodedString = WebUtility.HtmlDecode(controllerContext.HttpContext.Request.Form[bindingContext.ModelName]);
                return decodedString.Split(',').Select(s => long.Parse(s.Trim())).ToArray();
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
