     public class RequiredParametersAttribute : ActionFilterAttribute
        {
            private string[] requiredProperties;
    
            public RequiredParametersAttribute(params string[] props)
            {
                requiredProperties = props;
            }
    
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                foreach (var property in requiredProperties)
                {
                    //NOTE: assumption that action has only one parameter and looking only at first children in the object tree
                    object obj = context.ActionArguments.FirstOrDefault().Value;
                    if (obj == null || obj.GetType().GetProperty(property).GetValue(obj) == null || obj.GetType().GetProperty(property).GetValue(obj).Equals(GetDefaultValue(obj.GetType().GetProperty(property).PropertyType)))
                        context.ModelState.TryAddModelError(property, property +" is required.");
                }
            }
    
            public static object GetDefaultValue(Type type)
            {
                return type.GetTypeInfo().IsPrimitive ? Activator.CreateInstance(type) : null;
            }
        }
