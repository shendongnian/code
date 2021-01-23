        using System.Web.Http.Filters;
        using System.Net;
        using System.Net.Http;
        public class MyExceptionFilterAttribute : ExceptionFilterAttribute
        {
            public override void OnException(HttpActionExecutedContext context)
            {
                var request = context.Request;
                var response = request.CreateErrorResponse(HttpStatusCode.InternalServerError, context.Exception.Message);
                var content = (System.Net.Http.ObjectContent<System.Web.Http.HttpError>)response.Content;
                var errorValues = (System.Web.Http.HttpError)content.Value;
                errorValues["Message"] = context.Exception.Message;
                errorValues["ExceptionMessage"] = context.Exception.Message;
                errorValues["ExceptionType"] = context.Exception.GetType().Name;
                if (context.ActionContext != null)
                {
                    errorValues["ActionName"] = context.ActionContext.ActionDescriptor.ActionName;
                    errorValues["ControllerName"] = context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
                }
                context.Response = response;
            }
        }
