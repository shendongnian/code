    public class InheritingConstructorArgumentsInstanceProvider : StandardInstanceProvider
    {
        protected override IConstructorArgument[] GetConstructorArguments(
            MethodInfo methodInfo,
            object[] arguments)
        {
            return methodInfo
                .GetParameters()
                .Select((parameter, index) =>
                    new ConstructorArgument(
                        parameter.Name,
                        arguments[index],
                        true))
                .Cast<IConstructorArgument>()
                .ToArray();
        }
    }
