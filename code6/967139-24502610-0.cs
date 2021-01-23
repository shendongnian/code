    using System.Reflection;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using Microsoft.Security.Application;
    /// <summary>
    /// Sanitizes (HTML encodes) all strings on the model.
    /// </summary>
    /// <remarks>Use sparingly. Ideally don't use this and instead encode when outputting the values.
    /// This is used because we don't have control of other applications that may consume the data.</remarks>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class SanitizeInputAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments != null && actionContext.ActionArguments.Count == 1)
            {
                var requestParam = actionContext.ActionArguments.First();
                var properties = requestParam.Value.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(x => x.CanRead && x.CanWrite && x.PropertyType == typeof(string) && x.GetGetMethod(true).IsPublic && x.GetSetMethod(true).IsPublic);
                foreach (var propertyInfo in properties)
                {
                    propertyInfo.SetValue(requestParam.Value, Encoder.HtmlEncode(propertyInfo.GetValue(requestParam.Value) as string));
                }
            }
        }
    }
