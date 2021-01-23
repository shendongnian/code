    public class CustomTypedFactoryComponentSelector : DefaultTypedFactoryComponentSelector
    {
        protected override string GetComponentName(MethodInfo method, object[] arguments)
        {
            if(method.Name == "GetUser" && arguments.Length == 1 && arguments[0] is string)
            {
                return (string)arguments[0];
            }
            return base.GetComponentName(method, arguments);
        }
    }
