    public class FormFactoryComponentSelector : DefaultTypedFactoryComponentSelector
    {
        protected override Type GetComponentType(MethodInfo method, object[] arguments)
        {
            if (arguments.Length >= 1 && arguments[0] is Type)
            {
                return (Type)arguments[0];
            }
            return base.GetComponentType(method, arguments);
        }
    }
