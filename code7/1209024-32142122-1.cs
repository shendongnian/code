    public class InheritingConstructorArgumentsInstanceProvider : StandardInstanceProvider
    {
        protected override IConstructorArgument[] GetConstructorArguments(
            MethodInfo methodInfo, object[] arguments)
        {
            var parameters = methodInfo.GetParameters();
            var constructorArguments = new IConstructorArgument[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                constructorArguments[i] = new ConstructorArgument(
                    parameters[i].Name, arguments[i], true);
            }
            return constructorArguments;
        }
    }
