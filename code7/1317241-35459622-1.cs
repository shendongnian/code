    public class ParameterInheritingInstanceProvider : StandardInstanceProvider
    {
        private readonly List<string> _parametersToInherit = new List<string>();
    
        public ParameterInheritingInstanceProvider(params string[] parametersToInherit)
        {
            _parametersToInherit.AddRange(parametersToInherit);
        }
    
        protected override IConstructorArgument[] GetConstructorArguments(MethodInfo methodInfo, object[] arguments)
        {
            var parameters = methodInfo.GetParameters();
            var constructorArgumentArray = new IConstructorArgument[parameters.Length];
            for (var i = 0; i < parameters.Length; ++i)
                constructorArgumentArray[i] = new ConstructorArgument(parameters[i].Name, arguments[i], _parametersToInherit.Contains(parameters[i].Name));
            return constructorArgumentArray;
        }
    }
