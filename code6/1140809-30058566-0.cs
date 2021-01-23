    using System;
    using System.Reflection;
    using System.Web.Mvc;
    namespace Your.Namespace
    {
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public sealed class HttpDeleteLocalizedAttribute : ActionMethodSelectorAttribute
        {
            public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
            {
                bool result = false;
                string actionValue = controllerContext.HttpContext.Request.Form.Get("X-HTTP-Method-Override");
                if (actionValue != null)
                {
                    if (actionValue == Resources.Delete)
                        result = true;
                }
                return result;
            }
        }
    }
