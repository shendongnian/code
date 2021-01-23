    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
         private readonly Type _type;
         private readonly string _method;
         public ExceptionHandlingAttribute(Type type, string method){ _type = type; _method = method; }
         public override void OnException(HttpActionExecutedContext context)
         {
            var instance = Activator.CreateInstance(_type);
            var method = _type.GetMethod(_method);
            var result = method.Invoke(instance);
            //process result
        }
    }
