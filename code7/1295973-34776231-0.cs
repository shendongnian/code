    public class FooFilter : ActionFilterAttribute {
             public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext) {
                var objectContent = actionExecutedContext.Response.Content as ObjectContent;
                if (objectContent != null) {
                    var type = objectContent.ObjectType; //type of the returned object
                    var value = objectContent.Value; //holding the returned value
                }
    
            }
        }
