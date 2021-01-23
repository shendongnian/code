    public class AntiForgeryTokenFilterProvider : IFilterProvider
    {
        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            IEnumerable<FilterAttribute> filters = actionDescriptor.GetFilterAttributes(true);
    
            bool disableAntiForgery = filters.Any(f => f is DisableAntiForgeryCheckAttribute);
    
            string method = controllerContext.HttpContext.Request.HttpMethod;
    
            if (!disableAntiForgery
                && String.Equals(method, "POST", StringComparison.OrdinalIgnoreCase))
            {
                yield return new Filter(new ValidateAntiForgeryTokenAttribute(), FilterScope.Global, null);
            }
        }
    }
    
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class DisableAntiForgeryCheckAttribute : FilterAttribute
    {
    }
    
    // Usage:
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //**//
            FilterProviders.Providers.Add(new AntiForgeryTokenFilterProvider());
            //**//
        }
    }
    
    // Html Helper method
    public static class HtmlExtensions
    {
        public static MvcForm BeginSecureForm(this HtmlHelper html, string action, string controller)
        {
            var form = html.BeginForm(action, controller);
            html.ViewContext.Writer.Write(html.AntiForgeryToken().ToHtmlString());
    
            return form;
        }
    }
